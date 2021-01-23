    using System;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                int number = 6;
                string toDisplay = "";
    
                for (int i = 1; i <= number; i++)
                {
                    for (int j = 1; j <= number - i; j++) Console.Write(" ");
                    for (int k = 1; k <= i; k++)
                    {
                        toDisplay = (k == 1 || k == i && i != number)
                                    ?" *"
                                    : (i == number)
                                    ? " *"
                                    : "  ";
                        Console.Write(toDisplay);
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
