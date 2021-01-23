    private void checkBox1_Paint(object sender, PaintEventArgs e)
    {
        Point pt = new  Point(e.ClipRectangle.Left + 2, e.ClipRectangle.Top + 4);
        Rectangle rect = new Rectangle(pt, new Size(22, 22));
        using (Font wing = new Font("Wingdings", 14f))
            e.Graphics.DrawString("ü", wing, Brushes.DarkOrange,rect);
        e.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);
    }
