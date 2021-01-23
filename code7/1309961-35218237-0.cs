    `Form1 home = new Form1();
    home.button1.Click += new System.EventHandler(this.button1_Click);
    
    private void button1_Click(object sender, EventArgs e)
        {
            
            home.txtOn.Text = "test!";
    
            System.Diagnostics.Debug.WriteLine("button clicked!");
        }`
