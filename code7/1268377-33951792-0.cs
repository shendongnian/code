    //Create method which initialize treeview control with your nodes
    private void InitializeTreeView()
    {
        this.treeView1.Nodes.Add(new TreeNode("chapter1") { Tag = @"\include {chapter1}" });
        this.treeView1.Nodes.Add(new TreeNode("chapter2") { Tag = @"\include {chapter2}" });
        this.treeView1.Nodes.Add(new TreeNode("chapter3") { Tag = @"\include {chapter3}" });
        this.treeView1.Nodes[0].Nodes.Add(new TreeNode("section1") { Tag = @"\input {sec1}" });
        this.treeView1.Nodes[1].Nodes.Add(new TreeNode("section2") { Tag = @"\input {sec2}" });
        this.treeView1.Nodes[2].Nodes.Add(new TreeNode("section3") { Tag = @"\input {sec3}" });
    }
    private void Form_Load(Object sender, EventArgs e)
    {
        this.InitializeTreeView();
        //Now you can load your config
        this.LoadConfig();
    }
