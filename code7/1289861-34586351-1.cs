    private void TestScript_Paint(object sender, PaintEventArgs e)
    {
        g = e.Graphics;
        g.Clear(Color.White);
        if (dp == true)
        {
            g.FillRectangle(Brushes.Blue, x, y, 32, 32);
        }
        foreach (Rectangle r in rectangles)
            g.FillRectangle(Brushes.Blue, r);
        DoubleBuffered = true;
    }
