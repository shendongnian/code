    private void Form_Load(object sender, EventArgs e)
    {
        var projects= new List<Project>();
        //get data of projects from whenever you want and fill the list
        this.projectBindingSource.DataSource = projects;
        projects.ToList().ForEach(p =>
        {
            var projectNode = new TreeNode(p.Id);
            //Put project in tag of project node
            projectNode.Tag = p;
            p.Issues.ToList().ForEach(i =>
                {
                    var issueNode = new TreeNode(i.IssueId);
                    //Put issue in tag of issue node
                    issueNode.Tag = i;
                    projectNode.Nodes.Add(issueNode);
                });
            this.treeView1.Nodes.Add(projectNode);
        });
    }
