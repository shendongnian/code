    //TreviewNodesSelection
    private void TreviewNodesSelection(string item, int value)
    {
        textBox1.Text = item;
        listBoxMenu.Items.Add(item);
        //Find Nodes first
        Traverse(treeView1.Nodes, item);
        //Clear ListBox items
        ListBoxMain.Items.Clear();
        //Get a First ChildNode via Parenet Name
        if (treeView1.SelectedNode.Nodes.Count != 0)
        {
            foreach (TreeNode v in treeView1.SelectedNode.Nodes)
            {
                ListBoxMain.Items.Add(v.Text);
            }
        }
        else
        {
            MessageBox.Show("Now you can start calculation...");
        }
    }
