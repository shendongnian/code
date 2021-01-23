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
        public Node(string Name, bool NodeDir)
        {
            this.Name = Name;
            this.NodeDir = NodeDir;
            ParentKey = 1;
        }
    }
////////////////////////////////////////////
	static void Main(string[] args)
	{
		List<Node> n = new List<Node>();
		n.Add(new Node("bear", false));
		n.Add(new Node("monkey", true));
		n.Add(new Node("wolf", true));
		n.Add(new Node("Medeišis", false));
		n.Add(new Node("chicken", false));
		n.Add(new Node(null, false));
		n.Add(new Node(null, true));
		n.Add(new Node("stork", false));
		Program p = new Program();
		List<Node> res = p.BuildTreeHierarchy(n, 1);
		foreach (var a in res)
		{
			Console.WriteLine(a.Name + " " + a.NodeDir.ToString());
		}
		Console.ReadKey();
	}
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
		else
		{
			return null;
		}
	}
