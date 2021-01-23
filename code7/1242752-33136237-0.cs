    public void PermutationsTestMethod()
    {
        GetPermutationsOfString("MOM").ForEach(v => Debug.Print(v));
    }
    public List<string> GetPermutationsOfString(string value)
    {
        var resultList = new List<string>();
        for (var i = 1; i <= value.Length; i++)
        {
            var permutations = GetPermutations(Enumerable.Range(0, value.Length), i);
            resultList.AddRange(
                permutations
                    .Select(v => new string(v.Select(z => value[z]).ToArray()))
                    .Distinct()
                );
        }
        return resultList;
    }
    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });
        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }
