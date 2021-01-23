    var node_links = new List<NodeLink>
    {
        new NodeLink {From = "A", To = "B"},
        new NodeLink {From = "A", To = "C"},
        new NodeLink {From = "C", To = "D"},
        new NodeLink {From = "C", To = "E"},
        new NodeLink {From = "E", To = "F"},
        new NodeLink {From = "B", To = "F"}
    };
    RouteFinder finder = new RouteFinder();
    foreach (string path in finder.FindRoutes(node_links.ToArray(), "A", "F", 4))
    {
        Console.WriteLine(path);
    }
