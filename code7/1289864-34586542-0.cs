    public void AddTab()
    {
        this.tabArea = new TabControl();
        this.tabArea.Visible = true;
        Console.WriteLine("I AM RUNNING");
        string title = "TabPage " + (this.tabArea.TabCount + 1).ToString();
        TabPage myTabPage = new TabPage(title);
        this.tabArea.TabPages.Add(myTabPage);
        this.Controls.Add(tabArea);
    }
