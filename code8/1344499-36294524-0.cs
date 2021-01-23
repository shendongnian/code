    private void btAdd_Click(object sender, EventArgs e)
    {
        tabControl1.TabPages
            .Add(new TabPage("TabPage " + (tabControl1.TabCount + 1).ToString()));
    }
