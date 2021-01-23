    bool changed = false;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (changed)
        {
            Pen p = new Pen(Color.Red);
            Graphics g = e.Graphics;
            int diff = 1;
            g.DrawRectangle(p, new Rectangle(comboBox1.Location.X - diff, comboBox1.Location.Y - diff, comboBox1.Width + diff, comboBox1.Height + diff));
        }
    }
