    static List<Pair> PairsThatSumToN(int[] arr, int N)
    {
        return
        (
            from x in arr join y in arr on N - x equals y select new Pair(x, y)
        )
        .Distinct()
        .ToList();
    }
    public class Pair : Tuple<int, int>
    {
        public Pair(int item1, int item2) : base(item1, item2) { }
        public override bool Equals(object pair)
        {
            Pair dest = pair as Pair;
            return dest.Item1 == Item1 || dest.Item2 == Item1;
        }
        public override int GetHashCode()
        {
            return Item1 + Item2;
        }
    }
