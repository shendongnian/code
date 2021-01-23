    var routes = new List<Route>
    {
        new Route {From = "A", To = "B"},
        new Route {From = "A", To = "C"},
        new Route {From = "C", To = "D"},
        new Route {From = "C", To = "E"},
        new Route {From = "E", To = "F"},
        new Route {From = "B", To = "F"}
    };
    PathFinder finder = new PathFinder();
    foreach (string path in finder.FindRoutes(routes.ToArray(), "A", "F", 4))
    {
        Console.WriteLine(path);
    }
