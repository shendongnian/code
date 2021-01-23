        public static IList<string> ReadFile(string fileName)
        {
            var results = new List<string>();
            string[] target = File.ReadAllLines(fileName);
            foreach (string line in target)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    results.Add(line);
            }
            return results;
        }
