    var nodes = new List<TheClass>(); // fill ....
    var nodeListGroups = nodes.GroupBy(n => n.NodeIDs, new ListEqualityComparer<int>())
        .Select(grp => new TheClass
        {
            NodeID = grp.First().NodeID,
            Cost = grp.Sum(n => n.Cost),
            NodeIDs = grp.Key
    });
