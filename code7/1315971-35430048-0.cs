    [System.Web.Services.WebMethod]
    public static string MakeTreeData()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        var parentNodes = new List<Node>();
        var parent = new Node() { Id = "1", Text = "Parent 1", Nodes = new List<Node>() };
        var child = new Node() { Id = "2", Text = "Child 1", Nodes = new List<Node>() };
        parent.Nodes.Add(child);
        parentNodes.Add(parent);
        return js.Serialize(parentNodes);
    }
