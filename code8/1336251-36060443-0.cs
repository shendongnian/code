    static void Main(string[] args)
            {
                var l = string.Empty;
                while (l != "exit")
                {
                    l = Console.ReadLine();
                    int i = -1;
                    if (!int.TryParse(l, out i)) continue;
                    if (i % 2 == 0)
                    {
                        Console.WriteLine("even");
                        Console.WriteLine("enter again", i);
                    }
                    else if (i % 2 != 0)
                    {
                        Console.WriteLine("odd");
                        Console.WriteLine("enter again", i);
    
                    }
                }
                Console.ReadLine();
            }
