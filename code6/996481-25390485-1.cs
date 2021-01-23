    public class Currency : IComparable
    {
        public decimal Value { get; set; }
        public int CompareTo(Currency b)
        {
            return Value.CompareTo(b.Value);
        }
        public override string ToString()
        {
            return Value.ToString("C");
        }
    }
