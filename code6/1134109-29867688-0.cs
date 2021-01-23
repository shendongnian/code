        static void Main(string[] args)
        {
            var list = new List<int> { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1 };
            var result = list.Select((e, i) => new { Element = e, Index = i })
                .Where(e => e.Element == 1)
                .GroupBy(e => list.IndexOf(0, e.Index));
            foreach (var group in result)
            {
                foreach (var item in group)
                {
                    Console.Write(item.Element + " ");
                }
                Console.WriteLine();
            }
        }   
