    static HashSet<Tuple<int, int>> PairsThatSumToN(int[] arr, int N)
    {
        HashSet<Tuple<int, int>> result = new HashSet<Tuple<int, int>>(new IntTupleComparer());
        foreach(int i in arr)
        {
            int j = N - i;
            if (j != 0) result.Add(new Tuple<int, int>(i, j));
        }
        return result;
    }
    public class IntTupleComparer : IEqualityComparer<Tuple<int, int>>
    {
        public bool Equals(Tuple<int, int> x, Tuple<int, int> y)
        {
            return (x.Item1 == y.Item1 && x.Item2 == y.Item2) || (x.Item1 == y.Item2 && x.Item2 == y.Item1);
        }
        public int GetHashCode(Tuple<int, int> obj)
        {
            return (obj.Item1 + obj.Item2).GetHashCode();
        }
    }
    
