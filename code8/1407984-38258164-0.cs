            var qandADictionary = new Dictionary<string, int[]>
            {
                {"What is 1 + 1?", new[] {1, 2, 3, 4}},
                {"What is 1 + 2?", new[] {1, 2, 3, 4}},
                {"What is 1 + 3?", new[] {1, 2, 3, 4}},
                {"What is 1 + 4?", new[] {2, 3, 4, 5}}
            };
            foreach (var pair in qandADictionary)
            {
                var stringArray = Array.ConvertAll(pair.Value, i => i.ToString());
                 Console.WriteLine(string.Format("{0},{1}", pair.Key, string.Join(" ", stringArray)));
            }
            Console.ReadKey();
