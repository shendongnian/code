    public Form2()
            {
                InitializeComponent();
              //subscribe myTreeView1.AfterSelect event
                myTreeView1.AfterSelect += new TreeViewEventHandler(myTreeView1_AfterSelect);
            }
        private void myTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //cast sender into TreeView
            TreeView tree = sender as TreeView;
            if (tree != null) { 
              //do your logic here
            }
        }
