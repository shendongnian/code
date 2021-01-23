    public void SetDepths(Node node, int depth)
    {
        node.Depth = depth;
        foreach (var child in node.Items)
            SetDepths(child, depth + 1);
    }
    public void Sort(List<Node> nodes)
    {
        nodes = nodes.OrderBy(x => x.Depth).ToList();
    }
