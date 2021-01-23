    private void btnConfig_Click(object sender, EventArgs e)
    {
        var config = new Config(); 
        
        this.Visible = false;
        // this call blocks!
        var dialogResult = config.ShowDialog();
    
        // when the configform is closed, the code resumes here
        this.Visible = true;
    }
