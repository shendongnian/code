    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        switch (e.ProgressPercentage)
        {
            case 0:
                // we have s TreeNode, this is our root.
                treeView1.Nodes.Add((TreeNode) e.UserState);
                break;
            case 1:
                // we get a tuple, the parent and it's intended child.
                var tup = (Tuple<TreeNode,TreeNode>) e.UserState;
                tup.Item1.Nodes.Add(tup.Item2);
                break;
            default:
                break;
        }
    }
    
