        public static IEnumerable<List<int>> AllSequences(int start, int end, int size)
        {
            if (size == 0)
                return Enumerable.Repeat<List<int>>(new List<int>(), 1);
            return from i in Enumerable.Range(start, end)
                   from seq in AllSequences(start, end, size - 1)
                   select new List<int> { i }.Concat(seq).ToList();
        }
