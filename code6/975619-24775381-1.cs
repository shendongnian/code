    Random R = new Random();
    private void button1_Click(object sender, EventArgs e)
    {
        Image bmp = pictureBox2.Image;
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.DrawEllipse(Pens.Blue, R.Next(33), R.Next(33), R.Next(500), R.Next(500));
            g.DrawEllipse(Pens.Red, R.Next(33), R.Next(33), R.Next(500), R.Next(500));
            g.DrawEllipse(Pens.White, R.Next(33), R.Next(33), R.Next(500), R.Next(500));
        }
        pictureBox2.Image = bmp;
    }
