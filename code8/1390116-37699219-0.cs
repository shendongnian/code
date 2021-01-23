        static void Main(string[] args)
        {
            var names = new[] { "John", "Alex", "Peter", "Eric" };
            var letters = new[] { "A", "B", "C", "D" };
            var combinationSets = new List<Dictionary<string, string>>();
            foreach (var seq in letters.Permutate(4))
            {
                var dic = new Dictionary<string, string>();
                var vals = seq.ToArray();
                for (int i = 0; i < 4; i++)
                {
                    dic.Add(names[i], vals[i]);
                }
                combinationSets.Add(dic);
            }
            foreach (var dic in combinationSets)
            {
                foreach (var p in dic)
                {
                    Console.WriteLine(p.Key + ": " + p.Value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    public static IEnumerable<IEnumerable<T>> Permutate<T>(this IEnumerable<T> elements, int places, bool allowRepeats = false)
    {
        foreach (var cur in elements)
        {
            if (places == 1) yield return cur.Yield();
            else
            {
                var sub = allowRepeats ? elements : elements.ExceptOne(cur);   
                foreach (var res in sub.Permutate(places - 1, allowRepeats))
                {
                    yield return res.Prepend(cur);
                }
            }
        }
    }
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
        static IEnumerable<T> Prepend<T>(this IEnumerable<T> rest, T first)
        {
            yield return first;
            foreach (var item in rest)
                yield return item;
        }
        public static IEnumerable<T> ExceptOne<T>(this IEnumerable<T> src, T e, int n = 1)
        {
            foreach (var x in src)
                if (!x.Equals(e) || n-- == 0) yield return x;
        }
