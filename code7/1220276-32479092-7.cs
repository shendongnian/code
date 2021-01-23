    private bool _checking;
    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (!_checking && e.Node.Checked) {
            _checking = true;
            try {
                e.Node.CheckParentsAndChildren();
            } finally {
                _checking = false;
            }
        }
    }
