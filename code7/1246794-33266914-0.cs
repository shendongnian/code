        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadEventCode();
        }
        public void LoadEventCode()
        {
            this.Text = DateTime.Now.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(this); // <-- pass in Form1
        }
