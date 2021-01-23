    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        TreeNode node = new TreeNode(e.Argument.ToString());
        backgroundWorker1.ReportProgress(0, node);
        GetDirectoryNodes(e.Argument.ToString(), node);
    }
    
