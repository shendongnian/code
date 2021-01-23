    var dataSource = new DataSource();
    dataSource.Add(new A("Node 0, Property 0", "Node 0, Property 1", "Node 0, Property 2"));
    dataSource.Add(new A("Node 1, Property 0", "Node 1, Property 1", "Node 1, Property 2"));
    dataSource.Add(new A("Node 2, Property 0", "Node 2, Property 1", "Node 2, Property 2"));
    dataSource[0].SubNodes.Add(new A("Node 0.0, Property 0", "Node 0.0, Property 1", "Node 0.0, Property 2"));
    dataSource[0].SubNodes.Add(new A("Node 0.1, Property 0", "Node 0.1, Property 1", "Node 0.1, Property 2"));
    dataSource[0].SubNodes.Add(new A("Node 0.2, Property 0", "Node 0.2, Property 1", "Node 0.2, Property 2"));
    dataSource[1].SubNodes.Add(new A("Node 1.0, Property 0", "Node 1.0, Property 1", "Node 1.0, Property 2"));
    dataSource[1].SubNodes.Add(new A("Node 1.1, Property 0", "Node 1.1, Property 1", "Node 1.1, Property 2"));
    dataSource[1].SubNodes.Add(new A("Node 1.2, Property 0", "Node 1.2, Property 1", "Node 1.2, Property 2"));
    
    var treeList = new TreeList();
    
    treeList.Columns.AddField("Property0").Visible = true;
    treeList.Columns.AddField("Property1").Visible = true;
    treeList.Columns.AddField("Property2").Visible = true;
    treeList.DataSource = dataSource;
    
    panelControl1.Controls.Add(treeList);
    treeList.Dock = DockStyle.Fill;            
