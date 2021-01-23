    public class Tree
    {
        public string Name { get; private set; }
        public List<Tree> Trees { get; private set; }
        public Tree(string name)
        {
            this.Name = name;
            this.Trees = new List<Tree>();
        }
        public Tree(string name, params Tree[] nodes)
            : this(name)
        {
            if (nodes == null || !nodes.Any()) return;
            Trees.AddRange(nodes);
        }
    }
