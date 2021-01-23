    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        int borderMargin = 5;
        int stepSize = 10;    
        switch (e.KeyCode)
        {
            case Keys.Left:
            {
                int newLeft = Math.Max(0, pictureBox1.Left - stepSize);
                pictureBox1.Left = newLeft;
                break;
            }
            case Keys.Right:
            {
                int maxVal = panel1.Width - pictureBox1.Width - borderMargin;
                int newLeft = Math.Min(maxVal, pictureBox1.Left + stepSize);
                pictureBox1.Left = newLeft;
                break;
            }
            case Keys.Up:
            {
                int newTop = Math.Max(0, pictureBox1.Top - stepSize);
                pictureBox1.Top = newTop;
                break;
            }
            case Keys.Down:
            {
                int maxVal = panel1.Height - pictureBox1.Height - borderMargin;
                int newTop = Math.Min(maxVal, pictureBox1.Top + stepSize);
                pictureBox1.Top = newTop;
                break;
            }
        }
    }
