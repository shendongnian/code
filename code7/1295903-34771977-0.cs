    public class Tree : Dictionary<string, Tree>
    {
        public int Value;
        public Tree(int val) : base()
        {
            Value = val;
        }
    }
