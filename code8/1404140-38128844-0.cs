    private  void CreateNewTab()
    {
        TabPage tp1 = new TabPage();
        tp1.Text = "HSV";
        tp1.Name = "tpHSV";
        if (tabContMain.TabPages.ContainsKey(tp1.Name) == false)
        {
            HSVControl hsvc = new HSVControl();
            hsvc.Dock = DockStyle.Fill;
            hsvc.LoadData();
            tp1.Controls.Add(hsvc);
            tabContMain.TabPages.Add(tp1);
            tabContMain.SelectedTab = tp1;
        }
    }
