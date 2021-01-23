    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Parent != null)
        {
            var project = e.Node.Parent.Tag as Project;
            this.projectBindingSource.Position = this.projectBindingSource.IndexOf(project);
    
            var issue = e.Node.Tag as Issue;
            this.issuesBindingSource.Position = this.issuesBindingSource.IndexOf(issue);
        }
    }
