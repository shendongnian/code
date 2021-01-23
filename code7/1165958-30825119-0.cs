    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Choose a month: ");
                Console.ReadLine();
                Dictionary<string,int> dict = new Dictionary<string,int>(){
                    {"Januari", 31},  
                    {"Februari", 28},
                    {"Mars", 31},
                    {"April", 30},
                    {"Maj", 31},
                    {"Juni", 30},
                    {"Juli", 31},
                    {"Augusti", 31},
                    {"September", 30},
                    {"Oktober", 31},
                    {"November", 30},
                    {"December", 31}
                };
                int nummberOfDays = dict["Maj"];
                int inmat = int.Parse(Console.ReadLine());
                //get all the months with days = inmat
                Console.WriteLine(string.Join(",", dict.AsEnumerable().Where(x => x.Value == inmat).Select(y => y.Key).ToArray()));
                Console.ReadLine();
            }
        }
     
    }
    ​
