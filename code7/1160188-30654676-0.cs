    public class OrderAttribute : Attribute
    {
        public readonly int Pos;
        public OrderAttribute(int pos)
        {
            Pos = pos;
        }
    }
