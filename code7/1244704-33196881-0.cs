    Form f;
    TextBox t;
    void Main()
    {
        f = new Form();
        f.Text = "This is a test";
        t = new TextBox();
        f.Controls.Add(t);
        f.Load += onLoad;
        f.Shown += onShow;
        f.Show();
    }
    void onLoad(object sender, EventArgs e)
    {
        Process currentp = Process.GetCurrentProcess();
        if(!string.IsNullOrWhiteSpace(currentp.MainWindowTitle))
            t.Text = currentp.MainWindowTitle;
        else
            t.Text = "NO TITLE";
    }
    
    void onShow(object sender, EventArgs e)
    {
        // Uncomment these line to see the differences
        // if(!string.IsNullOrWhiteSpace(currentp.MainWindowTitle))
        //     t.Text = currentp.MainWindowTitle;
        // else
        //     t.Text = "NO TITLE";
    }
