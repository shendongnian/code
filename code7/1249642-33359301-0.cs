    using System;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                int number = 6;
    
                for (int i = 1; i <= number; i++)
                {
                    for (int j = 1; j <= number - i; j++)
                        Console.Write(" ");
                    for (int k = 1; k <= i; k++)
                    {                    
                        if (k == 1 || k == i && i !=number)
                        {
                            Console.Write(" *");
                        }
                        else
                        {
                            if (i == number) Console.Write(" *");
                            else Console.Write("  ");
                        }                    
                    }
                       
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
        }
    }
    //////////////////////////////////
          *
         * *
        *   *
       *     *
      *       *
     * * * * * *
    
    
    ////////////////////////////////////
