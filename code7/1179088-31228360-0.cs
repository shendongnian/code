        Form2 form2;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Owner = this;
            form2.Show();
        }
    
        private void btnClearForm2List_Click(object sender, EventArgs e)
        {
            form2.lstViewOfForm2.Clear();
        }
    }
