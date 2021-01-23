        public void UpdateLabels()
        {
           MyLabel.Text = (Name + " has placed " + MyBet.Amount + "$ " + "on " + label1.Text);      
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = "Brown Bear";
            UpdateLabels();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label1.Text = "Red Bear";
            UpdateLabels();
        }
        // ... etc ...
