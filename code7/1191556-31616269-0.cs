        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Form2 f2 = new Form2();
            f2.FormClosed += F2_FormClosed;
            f2.Show();
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }
