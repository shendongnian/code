    private static int[][] ListPerm(int[] mySet, int deep)
    {
        var all = new List<int[]>();
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
                    {
                        var z = new int[x.Length + 1];
                        z[0] = mySet[i];
                        x.CopyTo(z, 1);
                        return z;
                    }
                );
                all.AddRange(permn);
                int start = Array.FindIndex(perm1st, item => item[0] != mySet.ElementAt(i + 1));
                    if (start > 0)
                    {
                        var temp_cpy = new int[perm1st.Length - start][];
                        Array.Copy(perm1st, start, temp_cpy, 0, temp_cpy.Length);
                        perm1st = temp_cpy;
                    }
            }
        }
        return all.ToArray();
    }
