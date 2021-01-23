    protected void Page_Load(object sender, EventArgs e)
    {
        
        // Add to Panel
        TextBox txtTest = new TextBox();
        txtTest.ID = "txtTest";
        this.pnlDynamicControl.Controls.Add(txtTest);
        
    }
