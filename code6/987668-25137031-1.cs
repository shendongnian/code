    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Singh
    {
        class Program
        {
            static void Main(string[] args)
            {
                string Parts = "1^PartOne~2^PartTwo~3^PartThree~4^PartFour";
                string[] data = new string[5];
                data = Parts.Split('^', '~');
    
    
                for (int i = 0; i < data.Count(); i++)
                {
                    i++;
                    string names = data[i];
                    Console.WriteLine(names.ToString());
                }
                Console.ReadLine();
            }
        }
    }
