    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication5
    {
        class arrys {
            public int this[int index]
            {
                //get accessor 
                get
                {
                    if (index >= 0 && index < 16)
                       return index;
                    else
                        return -1;
                }
                //set accessor 
               /* set
                {
                }*/
            }
            }
        class Program
        {
            static void Main(string[] args)
            {
                arrys a1 = new arrys();
                    for (int i = 0; i <= 20; i++)
                    {
                        int a = a1[i];
                        Console.WriteLine("a:" + a);
                    }
                Console.ReadKey();
            }
        }
    }
