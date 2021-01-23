    private void applyBtn_Click(object sender, EventArgs e)
    {
        ProjectForm newProject1 = new ProjectForm( catTreeView );
        newProject1.MdiParent = this.ParentForm;
        newProject1.Text = "blabla";
        newProject1.Show();
    }
