    public class TupleComparer : IEqualityComparer<Tuple<string, string>>
    {
        public bool Equals(Tuple<string, string> x, Tuple<string, string> y)
        {
            return  (x.Item1 == y.Item1 && x.Item2 == y.Item2) ||
                    (x.Item1 == y.Item2 && x.Item2 == y.Item1);
        }
        public int GetHashCode(Tuple<string, string> obj)
        {
            return string.Concat(new string[] { obj.Item1, obj.Item2 }.OrderBy(x => x)).GetHashCode();
            //or
            //return (string.Compare(obj.Item1, obj.Item2) < 0 ? obj.Item1 + obj.Item2 : obj.Item2 + obj.Item1).GetHashCode(); 
        }
    }
