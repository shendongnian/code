       static void Main(string[] args)
        {
            foreach (var item in ListPerm())
            {
                Console.WriteLine(String.Join(",", item));
            }
            Console.Read();
        }
        
    
        private static IEnumerable<List<int>> ListPerm(HashSet<int> mySet = null, int deep = 5)
        {
            if (mySet == null)
            {
                mySet = initSet(8);
            }
            if (deep <= 0)
            {
                yield return Enumerable.Empty<int>().ToList();
            }
            for (int i = 0; i < mySet.Count - deep + 1; i++)
            {
                
                if (deep == 1)
                {
                    yield return new List<int>() { mySet.ElementAt(i) };
                }
                foreach (var item in ListPerm(new HashSet<int>(mySet.Skip(i+1)), deep - 1))
                {
                    var list = new List<int>() { mySet.ElementAt(i) };
                    list.AddRange(item);
                    yield return list;
                }
            }
        }
    
        private static HashSet<int> initSet(int lenght)
        {
            HashSet<int> ret = new HashSet<int>();
            for (int i = 0; i < lenght; i++)
            {
                ret.Add(i * 1  +  1); // just an example...
            };
            return ret;
        }
