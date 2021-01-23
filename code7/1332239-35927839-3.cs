    private Config config;
    private void btnConfig_Click(object sender, EventArgs e)
    {
        if(config==null || config.IsDisposed)
        {
            config = new Config(this); // Pass the main form into the constructor of config
        }
        config.ShowDialog(); 
        this.Visible = false;
    }
