        class Program
    {
        private static readonly char[] separators = { ' ' };
        private static List<string> lines;
        private static ConcurrentDictionary<string, int> freqeuncyDictionary;
        static void Main(string[] args)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            string path = @"C:\Users\James\Desktop\New Text Document.txt";
            lines = ReadLines(path);
            ConcurrentDictionary<string, int> test = GetFrequencyFromLines(lines);
            stopwatch.Stop();
            Console.WriteLine(@"Complete after: " + stopwatch.Elapsed.TotalSeconds);
        }
        private static List<string> ReadLines(string path)
        {
            lines = new List<string>();
            using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines;            
        }
        public static ConcurrentDictionary<string, int> GetFrequencyFromLines(List<string> lines)
        {
            freqeuncyDictionary = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(lines, line =>
            {
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (freqeuncyDictionary.ContainsKey(word))
                    {
                        freqeuncyDictionary[word] = freqeuncyDictionary[word] + 1;
                    }
                    else
                    {
                        freqeuncyDictionary.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
                    }
                }
            });
            return freqeuncyDictionary;
        }
    }
