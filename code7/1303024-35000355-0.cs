    public class Node
    {
        public IComparable Data;
        public Node Right;
        public Node Left;
        public Node(IComparable value)
        {
            Data = value;
            Right = Left = null;
        }
    }
