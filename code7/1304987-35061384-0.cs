    private void AddChildTreeViewNodes(DataTable treeViewData, TreeNode parentTreeViewNode)
    {
        DataView view = new DataView(treeViewData);
        foreach (DataRowView row in view)
        {
            TreeNode newNode = new TreeNode(row["client_name"].ToString(), row["idx_client"].ToString());
            parentTreeViewNode.ChildNodes.Add(newNode);
            newNode.PopulateOnDemand = true;
            // error caused by recursion below
            AddChildTreeViewNodes(treeViewData, newNode); // calls itself again REMOVE THIS
        }
    }
