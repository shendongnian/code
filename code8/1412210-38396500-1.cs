     private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Action == TreeViewAction.ByMouse)
        {
            // name of treeNode
            textBox4.Text = treeView1.SelectedNode.Name.ToString();
            // to show the ID
            textBox2.Text = ((int)treeView1.SelectedNode.Tag).ToString();
        }
    }
