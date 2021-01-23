    public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
    {
        foreach (Category c in db.Category)
        {
            DynamicNode n = new DynamicNode();
            n.Title = c.CategoryTitle;
            n.Key = "Kategoria_" + c.CategoryID;
            // Add the parent key
            n.ParentKey = "Home"; // (assumes you have a node with the key Home)
            // Add the controller and action
            n.Controller = "Category";
            n.Action = "Details";
            // Add any additional route values to match
            n.RouteValues.Add("id", c.CategoryID);
            // Add any route values to match regardless of value
            // n.PreservedRouteParameters.Add("myKey");
            yield return n;
        }
    }
