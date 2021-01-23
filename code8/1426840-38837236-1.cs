    private readonly MyForm _f1;
    
    public b(MyForm f1){
        InitializeComponents();
       
        _f1 = f1;
    }
    
    private void button1_Click(object sender, EventArgs e) {
        TabPage tp = new TabPage { };
        tp.Text = "NewTab";
        tp.Controls.Add(new b());
        
        //  assumes 'tabControl1' exists as a publicly accessible control
        _f1.tabControl1.TabPages.Add(tp);
    }
