    public Form1()
    {
        InitializeComponent();
        TreeNode tNode;
        //MAIN NODE 1
        tNode = treeView1.Nodes.Add("1.Water");
        tNode = treeView1.Nodes.Add("2.Air");
        tNode = treeView1.Nodes.Add("3.Soil");
        tNode = treeView1.Nodes.Add("4.Fire");
        // WATER NODE
        treeView1.Nodes[0].Nodes.Add("1.Salty");
        treeView1.Nodes[0].Nodes.Add("2.Fresh");
        treeView1.Nodes[0].Nodes.Add("3.Contaminated");
        // AIR NODE
        treeView1.Nodes[1].Nodes.Add("1.Fresh");
        treeView1.Nodes[1].Nodes.Add("2.Contaminated");
        // SOIL NODE
        treeView1.Nodes[2].Nodes.Add("1.Normal");
        treeView1.Nodes[2].Nodes.Add("2.Contaminated");
        // FIRE NODE
        treeView1.Nodes[3].Nodes.Add("1.Low");
        treeView1.Nodes[3].Nodes.Add("2.Mid");
        treeView1.Nodes[3].Nodes.Add("3.High");
        // SALTY NODE
        treeView1.Nodes[0].Nodes[0].Nodes.Add("1.AA");
        treeView1.Nodes[0].Nodes[0].Nodes.Add("2.BB");
        treeView1.Nodes[0].Nodes[0].Nodes.Add("3.CC");
        // FRESH NODE
        treeView1.Nodes[0].Nodes[1].Nodes.Add("1.DD");
        treeView1.Nodes[0].Nodes[1].Nodes.Add("2.EE");
        treeView1.Nodes[0].Nodes[1].Nodes.Add("3.FF");
        // CONTAMINATED NODE
        treeView1.Nodes[0].Nodes[2].Nodes.Add("1.XX");
        treeView1.Nodes[0].Nodes[2].Nodes.Add("2.YY");
        treeView1.Nodes[0].Nodes[2].Nodes.Add("3.ZZ");
        //Clear ListBox items
        ListBoxMain.Items.Clear();
        //Load ListBox First time
        foreach (TreeNode n in treeView1.Nodes)
        {
            ListBoxMain.Items.Add(n.Text);
        }
    }
