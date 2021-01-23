    private void pic_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var p = e.Location;
        p.Offset(-size.Width / 2, -size.Height / 2);
        Shapes.Add(new Rectangle(p, size));
        pic.Invalidate();
    }
