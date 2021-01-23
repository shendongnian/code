    public class LineItem : IComparable<LineItem>
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public bool Active { get; set; }
        public int CompareTo(LineItem other)
        {
            if (other.Num > this.Num)
                return -1;
            else if (other.Num == this.Num)
                return 0;
            else
                return 1;
        }
    }
