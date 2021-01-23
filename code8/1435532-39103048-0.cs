    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int counter = 0;
                int i = 0;
                int numberOfBoards = 35;
    
                for (; numberOfBoards > counter; i++, counter++)
                {
                    Console.WriteLine("Counter {0}/i {1}", counter, i);
    
                    //call your thread here.
                    //make sure that he exists.
                    //use somekind of timeout to finish
                    //alert the user in case of failure but move to the next anyway to avoid an infinite looping.
    
                    if (i == 13) i = 0;
                }
               
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
