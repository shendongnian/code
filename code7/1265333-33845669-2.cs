    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace PrintEvenNumbers
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Clear();
                SafeForWork();
                Console.WriteLine();
                JustShowingOff();
                Console.ReadLine();
            }
            private static void SafeForWork()
            {
                StreamReader myReader = new StreamReader(@"C:\Users\Public\NumbersFile.txt");
                string line = "";
                while (line != null)
                {
                    line = myReader.ReadLine();
                    int number = -1;
                    if (Int32.TryParse(line, out number))
                    {
                        if (number % 2 == 0)
                        {
                            Console.WriteLine(number);
                        }
                    }
                }
                myReader.Close();
            }
            private static void JustShowingOff()
            {
                List<String> Contents = File.ReadAllLines(@"C:\Users\Public\NumbersFile.txt").ToList();
                List<String> Evens = Contents.Where(var => (Int32.Parse(var)) % 2 == 0).ToList();
                Evens.ForEach(var => Console.WriteLine(var));            
            }
        }
    }
