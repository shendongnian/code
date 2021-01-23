    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.DefaultCellStyle.BackColor = RandColor();
        }
    
        private Color RandColor()
        {
            Random x = new Random();
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(x.Next(0, 255), x.Next(0, 255), x.Next(0, 255));
            return myRgbColor;
        }
