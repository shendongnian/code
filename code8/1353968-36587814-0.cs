    public static void Main()
            {
                GetData();
            }
            static void GetData()
            {
                int count = 11;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count * 2; j++)
                    {
                        var s = ((i + j == count) || (j - i == count)) ? "*" : " ";
                        Console.Write(s);
                    }
                    Console.WriteLine();
                }
    
                Console.WriteLine("-------------------------------");
                Console.WriteLine("------------Reverse------------");
                Console.WriteLine("-------------------------------");
    
                for (int i = count; i >= 0; i--)
                {
                    for (int j = count * 2; j >= 0; j--)
                    {
                        var s = ((i + j == count) || (j - i == count)) ? "*" : " ";
                        Console.Write(s);
                    }
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
