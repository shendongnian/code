            ChilForm frm = new ChilForm();
    
            public Parent()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //Shows the child
                frm.Show();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                //Changes color
                frm.ChangeTextboxColor();
            }
