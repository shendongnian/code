    class MyClass {
        private int ID = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtinvoiceno.Text = this.ID.ToString("D5");
        }
        protected void btnsavef1_Click(object sender, EventArgs e)
        {
            this.ID++;
            txtinvoiceno.Text = this.ID.ToString("D5");
        }
    }
