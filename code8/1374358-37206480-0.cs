    private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
    {
    	foreach (string path in paths)
    	{
    		string subPathAgg = string.Empty;
    		TreeNode lastNode = null;
    		foreach (string subPath in path.Split(pathSeparator))
    		{
    			subPathAgg += subPath + pathSeparator;
    			TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
    			if (nodes.Length == 0)
    				if (lastNode == null)
    					lastNode = treeView.Nodes.Add(subPathAgg, subPath);
    				else
    					lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
    			else
    				lastNode = nodes[0];
    		}
    	}
    }
