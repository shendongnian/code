       static void Main(string[] args)
        {
            foreach (var item in ListPerm())
            {
                Console.WriteLine(String.Join(",", item));
            }
            Console.Read();
        }
        
    
        private static List<List<int>> ListPerm(HashSet<int> mySet, int deep = 5)
        {
            if (mySet == null)
            {
                mySet = initSet(8);
            }
            if (deep <= 0)
            {
                return Enumerable.Empty<List<int>>().ToList();
            }
            List<List<int>> all = new List<List<int>>();
            for (int i = 0; i < mySet.Count - deep + 1; i++)
            {
                
                if (deep == 1)
                {
                    var list = new List<int>() { mySet.ElementAt(i) };
                    all.Add(list);
                }
                foreach (var item in ListPerm(new HashSet<int>(mySet.Skip(i+1)), deep - 1))
                {
                    var list = new List<int>() { mySet.ElementAt(i) };
                    list.AddRange(item);
                    all.Add(list);
                }
            }
            return all;
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
