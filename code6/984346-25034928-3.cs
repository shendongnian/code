        public Form1()
        {
            InitializeComponent();
            TextBox tb = new TextBox();
            tb.Name = "aa";
            tb.Text = "11";
            TextBox tb2 = new TextBox();
            tb2.Name = "bb";
            tb2.Text = "22";
            this.Controls.Add(tb);
            this.Controls.Add(tb2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Name.Equals("bb")) 
                        MessageBox.Show("bb value:" + c.Text);
                }
            }
        }
