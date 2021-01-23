    private readonly Form _f1;
    
    public b(Form f1){
        InitializeComponents();
       
        _f1 = f1;
    }
    
    private void button1_Click(object sender, EventArgs e) {
        TabPage tp = new TabPage { };
        tp.Text = "NewTab";
        tp.Controls.Add(new b());
        
        _f1.tabControl1.TabPages.Add(tp);
    }
