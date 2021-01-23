      private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Action == TreeViewAction.ByMouse)
        {
            Subanatomy suba = treeView1.SelectedNode.Tag as Subanatomy;
            if (suba != null)
            {
              // name of treeNode
              textBox4.Text = subA.SubAnatomyName;
              // to show the ID
              textBox2.Text = subA.SubAnatomyID.ToString();
            }
        }
    }
