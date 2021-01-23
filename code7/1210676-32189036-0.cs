        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.StateImageIndex = 0; // assuming 0 is the const for expanded navigation 
        }
        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.StateImageIndex = 1; // assuming 1 is the const for collapsed navigation 
        }
