    private void Form2_Load(object sender, EventArgs e)
    {
        MyConfig cfg = MyConfig.LoadConfig();
        Text = cfg.Title;
    }
