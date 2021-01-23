    public static void CreateResourceTree(TreeView selector,IEnumerable<SelectableResource> resources,SelectableResource onRefresh=null)
    {
        ActiveResources.Clear();
        ActiveResources.AddRange(resources.OrderByDescending(x=>x.FetchMeta("Priority").IntValue)
        .ThenBy(x=>x.Label)
        .ToList());
        onRefresh.IsSelected = true;
    }
