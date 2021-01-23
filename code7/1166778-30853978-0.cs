    private void SetCaptions()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        this.SuspendLayout();
        for (int i = 0; i != Controls.Count; i++)
        {
            resources.ApplyResources(Controls[i], Controls[i].Name, Program.Culture);
        }
        resources.ApplyResources(this, "$this", Program.Culture);
        this.ResumeLayout(false);
    }
