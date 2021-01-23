    private static int[][] ListPerm(int[] mySet = null, int deep)
    {
        var all = new List<int[]>();
        if (deep == mySet.Length)
        {
            return new int[][] { mySet};
        }
        if (deep == 1)
        {
            return mySet.Select(x => new int[] { x }).ToArray(); 
        }
        else
        {
            var perm1st = ListPerm(mySet.Skip(1).ToArray(), deep - 1);
            for (int i = 0; i < mySet.Count() - deep + 1; i++)
            {
                var permn = perm1st.Select(x =>
                Enumerable.Repeat(mySet.ElementAt(i),1).Concat(x).ToArray()
                );
                all.AddRange(permn);
                int start = Array.FindIndex(perm1st, item => item[0] != mySet.ElementAt(i + 1));
                perm1st = perm1st.Skip(start).ToArray();
            }
        }
        return all.ToArray();
    }
