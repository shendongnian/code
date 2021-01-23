    public IEnumerable<TreeModel> GetAllDescendants(IEnumerable<TreeModel> rootNodes)
    {
        var descendants = rootNodes.SelectMany(_ => GetAllDescendants(_.Children));
        return rootNodes.Concat(descendants);
    }
    public static TreeModel GetParent(this TreeModel rootNode, Func<TreeModel, bool> childSelector)
    {
        var allNodes = GetAllDescendants(new [] { rootNode });
        var parentsOfSelectedChildren = allNodes.Where(node => node.Children.Any(childSelector));
        return parentsOfSelectedChildren.Single();
    }
    m1.GetParent(_ => _.ID == 22);
