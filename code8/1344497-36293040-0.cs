    private void btAdd_Click(object sender, EventArgs e)
    {
        string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
        TabPage myTabPage = new TabPage(title);
        tabControl1.TabPages.Add(myTabPage);
    }
