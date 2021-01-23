    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab == tabControl1.TabPages["myTabPage"])
        {                
            this.Refresh();
            Application.DoEvents();
            doWorkFor300ms();                
        }
    }
