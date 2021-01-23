    private void updateChildrenNodes(TreeNode node, bool isChecked) //recursive call
    {
        node.Checked = isChecked;
        if (node.Nodes.Count > 0) //has children, do recursive call            
            foreach (TreeNode childNode in node.Nodes)
                updateChildrenNodes(childNode, isChecked);            
    }
    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        TreeView view = sender as TreeView;
        TreeNode node = view.SelectedNode;
        bool isChecked = node.Checked;
        updateChildrenNodes(node, isChecked);
    }
    List<TreeNode> checkedNodes = new List<TreeNode>();
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        TreeView treeView = sender as TreeView;
        listView1.Clear(); //reset all the nodes
        nodes.Clear(); //clears the list
        //grab whatever you need from the TreeView, check if the TreeNode is checked
        //do the same trick by recursive call to put the checked nodes to checkedNodes list
        foreach (TreeNode checkedNode in checkedNodes)
        {
            //do something, use this info to put in listView1
        }            
    }
