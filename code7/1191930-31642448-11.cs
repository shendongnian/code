    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        foreach (Tuple<Label, Label> t in lines)
        {
            Point p1 = new Point(t.Item1.Left + t.Item1.Width / 2, 
                                 t.Item1.Top + t.Item1.Height / 2);
            Point p2 = new Point(t.Item2.Left + t.Item2.Width / 2, 
                                 t.Item2.Top + t.Item2.Height / 2);
            e.Graphics.DrawLine(Pens.Black, p1, p2);
        }
    }
