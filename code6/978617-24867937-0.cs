    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[50];
            var pos = new List<int>();
            string result;
            do
            {
                Console.Write("Now enter a number to compare: ");
                result = Console.ReadLine();
                int c;
                if (int.TryParse(result, out c))
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == c)
                        {
                            pos.Add(j);
                        }
                    }
                    if (pos.Count == 0)
                    {
                        Console.WriteLine("Sorry this number does not match");
                    }
                    else
                    {
                        Console.WriteLine("The number {0} appears {1} time(s)", c, pos.Count);
                    }
                }
            } while (result != "exit");
        }
    }
