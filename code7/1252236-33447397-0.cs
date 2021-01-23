    class ChangeColor 
    
        {
            public Form1 form1 { get; set; }
            public ChangeColor(Form1 form1)
            {
                this.form1 = form1;
            }
            Public void RedPanel()
            {
                this.pnlCanvas.BackColor = Color.Red;
            }
    
    }
