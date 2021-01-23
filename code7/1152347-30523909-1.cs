        public Form1 frm1;
        public Form2(Form1 gridForm)
        {
            InitializeComponent();
            frm1 = gridForm;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (frm1.DataGridView1.Rows.Count < 5)
            {
                frm1.DataGridView1.Rows.Add(txtOrderNo.Text, txtDesc.Text);
                frm1.DataGridView1.Refresh();
                txtOrderNo.Text = txtDesc.Text = "";
                if (frm1.DataGridView1.Rows.Count == 5) this.Close();
            }
            else
            {
                MessageBox.Show("You can only add up to 5 items.");
            }
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
