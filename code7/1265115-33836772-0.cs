    List<int> path = new List<int>();
    BinaryTreeNode found = new DepthFirstSearch(root).Search();
    while(found != null)
    {
        path.Push(found.Data);
        found = found.Parent;
    }
    string stringPath = String.Join("-", path);
