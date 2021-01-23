    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node(int v)
        {
            value = v;
            left = right = null;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
