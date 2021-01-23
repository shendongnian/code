    var dataSource = new DataSource();
    //Add top level nodes
    dataSource.Add(new A("Node 0, Property 0", "Node 0, Property 1", "Node 0, Property 2"));
    dataSource.Add(new A("Node 1, Property 0", "Node 1, Property 1", "Node 1, Property 2"));
    dataSource.Add(new A("Node 2, Property 0", "Node 2, Property 1", "Node 2, Property 2"));
    //Add subnodes for first node.
    dataSource[0].SubNodes.Add(new A("Node 0.0, Property 0", "Node 0.0, Property 1", "Node 0.0, Property 2"));
    dataSource[0].SubNodes.Add(new A("Node 0.1, Property 0", "Node 0.1, Property 1", "Node 0.1, Property 2"));
    dataSource[0].SubNodes.Add(new A("Node 0.2, Property 0", "Node 0.2, Property 1", "Node 0.2, Property 2"));
    //Add subnodes for second node.
    dataSource[1].SubNodes.Add(new A("Node 1.0, Property 0", "Node 1.0, Property 1", "Node 1.0, Property 2"));
    dataSource[1].SubNodes.Add(new A("Node 1.1, Property 0", "Node 1.1, Property 1", "Node 1.1, Property 2"));
    dataSource[1].SubNodes.Add(new A("Node 1.2, Property 0", "Node 1.2, Property 1", "Node 1.2, Property 2"));
    //Add subnodes for second node in fisrt subnode.
    dataSource[0].SubNodes[1].SubNodes.Add(new A("Node 0.1.0, Property 0", "Node 0.1.0, Property 1", "Node 0.1.0, Property 2"));
    dataSource[0].SubNodes[1].SubNodes.Add(new A("Node 0.1.1, Property 0", "Node 0.1.1, Property 1", "Node 0.1.1, Property 2"));
    dataSource[0].SubNodes[1].SubNodes.Add(new A("Node 0.1.2, Property 0", "Node 0.1.2, Property 1", "Node 0.1.2, Property 2"));
    var gridControl = new GridControl();
    var view = new GridView(gridControl);           
    gridControl.MainView = view;
    gridControl.DataSource = dataSource;
    gridControl.Dock = DockStyle.Fill;
    view.OptionsDetail.ShowDetailTabs = false;
    Controls.Add(gridControl);
