    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] months = { "Jan","Feb","Mar" };
                int[] years = { 2015, 2014, 2013 };
                int[,] important = { { 1, 2, 3 }, { 3, 4, 6 }, { 8, 16, 1 } };
    
                Console.Write("\t");
                foreach (string month in months)
                {
                    Console.Write(month + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
                foreach (int year in years)
                {
                    Console.Write(year.ToString());
                    foreach (var month in months)
                    {
                        Console.Write("\t" + important[years.ToList<int>().IndexOf(year),months.ToList<string>().IndexOf(month)].ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.ReadKey();
                
            }
        }
    }
