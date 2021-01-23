        static void Main(string[] args)
        {
            var spellsList = new List<short[]>();
            spellsList.Add(new short[] {4, 12 });
            spellsList.Add(new short[] {4, 12 });
            spellsList.Add(new short[] {12, 4 });
            spellsList.Add(new short[] { 1, 8});
            spellsList.Add(new short[] {3, 12});
            spellsList.Add(new short[] {8, 1 });
            spellsList.Add(new short[] {8, 1 });
            spellsList.Add(new short[] {8, 1 });
            spellsList.Add(new short[] {8, 1 });
            var result = spellsList.Select(s => s[0] > s[1] ? String.Format("{0},{1}", s[0], s[1]) : String.Format("{0},{1}", s[1], s[0]))
                                   .GroupBy(s => s)
                                   .OrderByDescending(g => g.Count())
                                   .ToList();
            result.ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()} times"));
            Console.Read();
        }
