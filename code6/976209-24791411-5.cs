    var nodes = new List<TheClass>(); // fill ....
    var uniqueAndSummedNodes = nodes
        .GroupBy(n => n.NodeIDs, new ListEqualityComparer<int>())
        .Select(grp => new TheClass
        {
            NodeID = grp.First().NodeID,  // just use the first, change accordingly
            Cost = grp.Sum(n => n.Cost),
            NodeIDs = grp.Key
        });
    nodes = uniqueAndSummedNodes.ToList();
