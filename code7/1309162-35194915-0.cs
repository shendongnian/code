        int sc = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            sc += 10;
            this.HorizontalScroll.Value = sc;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.HorizontalScroll.Enabled = true;
            this.HorizontalScroll.Maximum = 500; //Calculate this value
        }
