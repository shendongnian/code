    private void Form1_Load(object sender, EventArgs e)
    {
        var allDlls = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll");
        if (allDlls.Any())
        {
            this.Close();
        }
    }
