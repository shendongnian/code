        private void Form1_Load(object sender, EventArgs e)
        {
            var Form2 = new Form2();
            Form2.Show();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Status == "Form2Visible")
            {
                this.Hide();
            }
        }
