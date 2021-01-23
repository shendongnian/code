    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Climate 02_08_2016.csv");
            var fileContents = ReadFile(filePath);
            foreach (var line in fileContents)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        public static IList<string> ReadFile(string fileName)
        {
            var results = new List<string>();
            var lines = File.ReadAllLines(fileName);
            for (var i = 0; i < lines.Length; i++)
            {
                // Skip the line with column names
                if (i == 0)
                {
                    continue;
                }
                // Replace space with a comma
                var replace = lines[i].Replace(' ', ',');
                results.Add(replace);
            }
            return results;
        }
    }
