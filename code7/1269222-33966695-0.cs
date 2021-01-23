    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections; // add this line here
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SortedList<string,int> list = new SortedList<string,int>;
                string ST_AR_NAMES;
                int IN_AR_Scores;
                while(!ST_AR_NAMES.Equals("EXIT"))
                {
        
                    Console.WriteLine("Please enter your name ");
                    ST_AR_NAMES=Console.ReadLine();
                    if(!ST_AR_NAMES.Equals("EXIT"))
                    {
                        Console.WriteLine("Please enter your score");
                        IN_AR_Scores = Convert.ToInt32(Console.ReadLine());
                        list.Add(ST_AR_NAMES,IN_AR_Scores);
    
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine("Name: {0} - score: {1}", 
                              list.GetByIndex(i), list[list.GetByIndex(i)]);
    
                        }
                    }
                }
            }
        }
    }
