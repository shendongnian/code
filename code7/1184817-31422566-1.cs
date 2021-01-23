        private static void TestSplitJson(string json, string tokenName)
        {
            var builders = new List<StringBuilder>();
            using (var reader = new StringReader(json))
            {
                SplitJson(reader, tokenName, 2, i => { builders.Add(new StringBuilder()); return new StringWriter(builders.Last()); }, Formatting.Indented);
            }
            foreach (var s in builders.Select(b => b.ToString()))
            {
                Console.WriteLine(s);
            }
        }
