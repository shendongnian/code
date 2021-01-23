    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
    {
        if (tabControl1.SelectedTab == tabPage1)
        {
            //Attach only once
            if (tabPage1.HasChildren)
                return;
            myDialog1 dg = new myDialog1();
            dg.TopLevel = false;
            dg.Dock = DockStyle.Fill;
            dg.Parent = tabPage1;
            dg.Show();
        }
        else if (tabControl1.SelectedTab == tabPage2)
        {
            if (tabPage2.HasChildren)
                return;
            myDialog2 dg = new myDialog2();
            dg.TopLevel = false;
            dg.Dock = DockStyle.Fill;
            dg.Parent = tabPage2;
            dg.Show();
        }
        else if (tabControl1.SelectedTab == tabPage3)
        {
           //and so on
        }
    }
