    namespace ConsoleApplication1
    {
        class Program
        {
            public static int isnegative;
    
            static void Main()
            {
                isnegative = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (isnegative == 0)
                    {
                        i = i;
                        isnegative = 0;
                    }
                    else
                    {
                        i = i*(-1);
                        isnegative = 1;
                    }
                    Console.WriteLine(i);
                }
    
                Console.ReadLine();
            }
        }
    }
