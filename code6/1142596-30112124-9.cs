    // get our nodes from the database:
    var nodes = db.Nodes
      .Select(n => new NodeVM()
      {
        // map fields or use AutoMapper... whatever
      })
      .ToList(); 
    nodes = nodes.Select(node =>
      {
        node.Nodes = nodes.Where(subnode => subnode.ParentID == node.Id).Tolist();
        return node;
      })
      .ToList();
      var model = new TreeVM();
      model.Nodes = new Stack(nodes
        // Find only Parent Elements
        .Where(node => !nodes.Any(subnode => subnode.ParentiD = node.Id));
        // Reverse list, we are using a stack (LILO)
        .Reverse()
        .ToList());
