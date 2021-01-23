    class Node
    {
        public int? ID;
        public string Name;
        public string Feature;
        public bool NodeDir;
        public int? ParentKey;
        public List<Node> Left;
        public List<Node> Right;
        public Node(){ }
        public Node(int? ID, string Name, bool NodeDir, int? ParentKey)
        {
            this.ID = ID;
            this.Name = Name;
            this.NodeDir = NodeDir;
            this.ParentKey = ParentKey;
        }
    }
////////////////////////////////////////////
	static void Main(string[] args)
	{
        List<Node> nodes = new List<Node>();
        nodes.Add(new Node(1,"bear", false, null));
        nodes.Add(new Node(2,"monkey", true,1));
        nodes.Add(new Node(3,"wolf", true, 1));
        nodes.Add(new Node(4, "Medeišis", false, 2));
        nodes.Add(new Node(5, "chicken", false, 3));
        nodes.Add(new Node(6, null, false, 3));
        nodes.Add(new Node(7, null, true, 4));
        nodes.Add(new Node(8, "stork", false, 4));
        Program p = new Program();
        //List<Node> res = p.BuildTreeHierarchy(n, null);
        foreach (Node a in nodes)
        {
            List<Node> nodeSub = nodes.Where(n => n.ParentKey == a.ID).ToList<Node>();
            a.Left = nodeSub.Where(n => n.NodeDir.Equals(false)).ToList<Node>();
            a.Right = nodeSub.Where(n => n.NodeDir.Equals(true)).ToList<Node>();
        }
        foreach (var a in nodes)
        {
            Console.WriteLine(a.ID.ToString() + a.Name + " " + a.NodeDir.ToString() + a.ParentKey.ToString());
        }
        Console.ReadKey();
	}
    // not using this function now
	public List<Node> BuildTreeHierarchy(List<Node> node, int? pKey)
	{
        var nodesWithNodeDir = node.Where(n => n.NodeDir.Equals(false));
        if (nodesWithNodeDir.Count() > 0)
        {
            return nodesWithNodeDir.Where(n => n.ParentKey == pKey)
            .Select(n => new Node()
            {
                ID = n.ID,
                Name = n.Name,
                Feature = n.Feature,
                NodeDir = n.NodeDir,
                ParentKey = n.ParentKey,
                // Left = BuildTreeHierarchy(node, n.ID) // avoid  Reentrancy for now.
            }).ToList();
        }
        nodesWithNodeDir = node.Where(n => n.NodeDir.Equals(true));
        if (nodesWithNodeDir.Count() > 0)
        {
            return nodesWithNodeDir.Where(n => n.ParentKey == pKey)
            .Select(n => new Node()
            {
                ID = n.ID,
                Name = n.Name,
                Feature = n.Feature,
                NodeDir = n.NodeDir,
                ParentKey = n.ParentKey,
                // Right = BuildTreeHierarchy(node, n.ID) // avoid  Reentrancy for now.
            }).ToList();
        }
        else
        {
            return new List<Node>();
        }
	}
