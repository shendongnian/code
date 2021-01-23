    public Form1 f1 { get; private set; }
    
    private void button1_Click(object sender, EventArgs e)
    {
        if(f1 == null) { f1 = this; }
        TabPage tp = new TabPage { };
        tp.Text = "NewTab";
        tp.Controls.Add(new b());
        f1.tabControl1.TabPages.Add(tp);  //>>> errors here
    }
