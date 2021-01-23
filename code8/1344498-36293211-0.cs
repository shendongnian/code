    private void button28_Click(object sender, EventArgs e)
    {
         string title = "" + (tabControl2.TabCount + 1).ToString();
         TabPage myTabPage = new TabPage(title);
         tabControl2.TabPages.Add(myTabPage);
    }
