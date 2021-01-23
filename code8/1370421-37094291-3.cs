    public class TupleModifier<T1, T2, T3, T4>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }
        public T4 Item4 { get; set; }
        public TupleModifier() { }
        public static implicit operator TupleModifier<T1, T2, T3, T4>(Tuple<T1, T2, T3, T4> t)
        {
            return new TupleModifier<T1, T2, T3, T4>()
            {
                Item1 = t.Item1,
                Item2 = t.Item2,
                Item3 = t.Item3,
                Item4 = t.Item4
            };
        }
        public static implicit operator Tuple<T1, T2, T3, T4>(TupleModifier<T1, T2, T3, T4> t)
        {
            return Tuple.Create(t.Item1, t.Item2, t.Item3, t.Item4);
        }
    }
