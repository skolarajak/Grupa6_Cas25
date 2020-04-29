using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cas25
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("QA Telefonski Imenik\n");
                Console.WriteLine("1. Unos novog imena");
                Console.WriteLine("2. Listanje imena");
                Console.WriteLine("3. Pretraga");
                Console.WriteLine("Q. Kraj rada");
                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        AddNewName();
                        break;
                    case "2":
                        ListNames();
                        break;
                    case "3":
                        SearchForName();
                        break;
                    case "Q":
                        break;
                    default:
                        break;
                }
            } while (choice.ToUpper() != "Q");
        }

        static void AddNewName()
        {
            string firstName, lastName, address, phone, choice;
            do
            {
                Console.Write("Unesite ime > ");
                firstName = Console.ReadLine();
                Console.Write("Unesite prezime > ");
                lastName = Console.ReadLine();
                Console.Write("Unesite adresu > ");
                address = Console.ReadLine();
                Console.Write("Unesite telefon > ");
                phone = Console.ReadLine();

                FileManagement.Store(firstName, lastName, address, phone);

                Console.WriteLine("\nDa li zelite unos nove osobe? Ukoliko zelite, otkucajte slovo 'Y' i ENTER, ili samo ENTER ukoliko zelite da prekinete.");
                choice = Console.ReadLine();
                Console.WriteLine("");
            } while (choice.ToUpper() == "Y");
        }

        static void ListNames()
        {
            Console.Clear();
            DisplayNames(FileManagement.Read());
        }

        static void SearchForName()
        {
            string search;
            Console.Write("Unesite termin za pretragu (mora sadrzati najmanje 3 slova) > ");
            search = Console.ReadLine();
            if ((search == "") || (search.Length < 3))
            {
                return;
            }
            List<string> searchResults = new List<string>();
            List<string> listOfNames = FileManagement.Read();
            foreach(string name in listOfNames)
            {
                if (name.ToUpper().Contains(search.ToUpper()))
                {
                    searchResults.Add(name);
                }
            }
            DisplayNames(searchResults);
        }

        static void DisplayNames(List<string> listOfNames)
        {
            string[] details;
            Console.WriteLine("Ime\tPrezime\t\tTelefon\tAdresa");
            Console.WriteLine("------------------------------------------------------------");
            foreach (string name in listOfNames)
            {
                details = name.Split(';');
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", details[0], details[1], details[3], details[2]);
            }
            Console.ReadKey();
        }
    }
}
