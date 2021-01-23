    static void Main()
            {
                const int maxLineNumber = 5;
                for (var itr = 1; itr <= maxLineNumber; itr++)
                {
                    for (var innerItr = 1; innerItr <= maxLineNumber; innerItr++)
                    {
                        if (innerItr == itr)
                        {
                            Console.Write(itr);
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
