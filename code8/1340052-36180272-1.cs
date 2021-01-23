    protected override void OnPaint(PaintEventArgs e)
    {
       // If there is an image and it has a location, 
       // paint it when the Form is repainted.
       base.OnPaint(e);
       PointF[] rotatedVertices = // Your rotated rectangle vertices
       e.Graphics.DrawPolygon(yourPen, rotatedVertices);
       // OR
       e.Graphics.FillPolygon(new SolidBrush(Color.Red), rotatedVertices);
    }
