    private void button1_Click(object sender, EventArgs e)
    {
        CreatePageGrid(qsreach.ToList(), "Page 1");
        CreatePageGrid(qsreach2.ToList(), "Page 2");
        CreatePageGrid(qsreach3.ToList(), "Page 3");
    }
    TabControl dynamicTab;
    private void CreatePageGrid(object dataSource, string pageName)
    {
        if (dynamicTab == null)
        {
            dynamicTab = new TabControl();
            this.Controls.Add(dynamicTab);
        }
    
            DataGridView dvg = new DataGridView();
            TabPage t2 = new TabPage();
            dvg.DataSource = dataSource;
            t2.Text = pageName;
            t2.Controls.Add(dvg);
            dynamicTab.Controls.Add(t2);
        }
