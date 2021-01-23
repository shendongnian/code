             if (textBox1.Text == "")
            {
                pictureBox1.BackColor = Color.Transparent;
            }
            else if (textBox1.Text.Length >= 8)
            {
                pictureBox1.BackColor = Color.Green;
            }
            else if ( textBox1.Text.Length < 8)
            {
                pictureBox1.BackColor = Color.Red;
            }
