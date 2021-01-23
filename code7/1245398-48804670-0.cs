    namespace PurushLogics
    {
        class Purush_EvenNoOddNo
        {
         
            //Print Even Number & Odd Numbers , seperated
            static void Main()
            {
    
                int start = 50;
                int end = 100;
    
                for (int j = start; j <= end; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(j);
                        if (j < end) // To avoid print , at the end
                        {
                            Console.Write(",");
                        }
                           
                    }
                } Console.WriteLine();
                for (int j = start; j <= end; j++)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write(j);
                        if (j < end-1)
                        {
                            Console.Write(",");// To avoid print , at the end
                        }
                          
                    }
                } Console.WriteLine();
                Console.ReadLine();
    
            }
            
        }
    }
