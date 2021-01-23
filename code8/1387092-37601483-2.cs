    static List<Node> ReadNodes(string fileName)
    {
        // I'm leaving that part for you
    }
    static List<Node> GetDiff(List<Node> nodes1, List<Node> nodes2)
    {
    	if (nodes2 == null || nodes2.Count == 0) return null;
    	if (nodes1 == null || nodes1.Count == 0) return nodes2;
    	var map = nodes1.ToDictionary(n => n.Text);
    	var diff = new List<Node>();
    	foreach (var n2 in nodes2)
    	{
    		Node n1;
    		if (!map.TryGetValue(n2.Text, out n1))
    			diff.Add(n2);
    		else
    		{
    			var childDiff = GetDiff(n1.Children, n2.Children);
    			if (childDiff != null && childDiff.Count > 0)
    				diff.Add(new Node { Text = n2.Text, Children = childDiff });
    		}
    	}
    	return diff;
    }
    static void WriteDiff(TextWriter output, List<Node> nodes, int indent = 0)
    {
    	if (nodes == null) return;
    	foreach (var node in nodes)
    	{
    		for (int i = 0; i < indent; i++)
    			output.Write(' ');
    		output.WriteLine(node.Text);
    		WriteDiff(output, node.Children, indent + 4);
    	}
    }
