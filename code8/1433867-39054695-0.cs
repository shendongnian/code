    bool changed = false;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (changed)
        {
            Pen p = new Pen(Color.Red);
            Graphics g = e.Graphics;
            int variance = 1;
            g.DrawRectangle(p, new Rectangle(comboBox1.Location.X - variance, comboBox1.Location.Y - variance, comboBox1.Width + variance, comboBox1.Height + variance));
        }
    }
