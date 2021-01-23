    private void AdoSample_Load(object sender, EventArgs e)
    {
        if(this.UserTitle.ToLower=="staff")
            this.MasterListButton.Enabled = false;
        else
            this.MasterListButton.Enabled = true;
    }
