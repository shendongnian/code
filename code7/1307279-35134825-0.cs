    List<Item> list = ...;
    // Pre create all nodes and build map by Id for fast lookup
    var nodeById = list
        .Select(item => new TreeViewModel { Id = item.Id, Text = item.Text })
        .ToDictionary(item => item.Id);
    // Build hierarchy
    var tree = new List<TreeViewModel>();
    foreach (var item in list)
    {
        var nodeList = item.ParentId == null ? tree, nodeById[item.ParentId.Value].Children;
        nodeList.Add(nodeById[item.Id]);
    }
