    public IEnumerable<TreeModel> GetAllDescendants(IEnumerable<TreeModel> rootNodes)
    {
        var children = rootNodes.SelectMany(_ => _.Children);
        return rootNodes.Concat(children);
    }
    public static TreeModel GetParent(this TreeModel rootNode, Func<TreeModel, bool> childSelector)
    {
        var allNodes = GetAllDescendants(new [] { rootNode });
        var parentsOfSelectedChildren allNodes.Where(node => node.Children.Any(childSelector));
        return parentsOfSelectedChildren.Single();
    }
    m1.GetParent(_ => _.ID == 22);
