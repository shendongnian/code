    private static void Main(string[] args)
        {
            int testCases = Int32.Parse(Console.ReadLine());
            var print = new List<string>();
            while (testCases-- > 0)
            {
                var line = Console.ReadLine();
                print.Add(line.StartsWith("simon says ") ? line.Remove(0, 11) : "");
            }
            foreach (var simonSaid in print)
                Console.WriteLine(simonSaid);
        }
