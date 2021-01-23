    private void addTabButton_Click(object sender, EventArgs e)
    {
       Tabpage tp = new TabPage();
       tp.Name = "tp" + this.tabControl1.TabCount;
       tp.Text = "tp" + this.tabControl1.TabCount;
       tp.Controls.Add(new Label()); //Or whatever you want added.
       this.tabControl1.TabPages.Add(tp);
    }
