    private void ShowLineJoin(PaintEventArgs e)
    {
        // Create a new pen with the specified color and width.
        using (Pen skyBluePen = new Pen(Brushes.Blue, 1))
        {
            // Set the LineJoin property.
            skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            // Draw a rectangle.
            e.Graphics.DrawRectangle(skyBluePen,
            new Rectangle(0, 0, 200, 200));
        }
    }
