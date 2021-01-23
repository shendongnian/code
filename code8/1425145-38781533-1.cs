    private static void Main(string[] args)
            {
            string s = Console.ReadLine();
            if (s.Length >= 2 && s.Substring(0, 2) == "20")
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();
        }
