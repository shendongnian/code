    Point oldCoords;
    GraphicsPath graphicsPaths = new GraphicsPath() { FillMode = FillMode.Winding };
    bool spaceFound = false;
    private void drawPanel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && graphicsPaths.IsVisible(e.Location))
        {
            spaceFound = true;
            drawPanel1.Invalidate(); 
        }
    }
    private void drawPanel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (oldCoords.IsEmpty)  graphicsPaths.StartFigure();
            else
            {
                graphicsPaths.AddLine(oldCoords, new Point(e.X, e.Y));
                drawPanel1.Invalidate(); 
            }
            oldCoords = new Point(e.X, e.Y);
        }
        else oldCoords = Point.Empty;
    }
    private void drawPanel1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Black, 2f))
            e.Graphics.DrawPath(pen, graphicsPaths);
        if (spaceFound == true)
        {
            e.Graphics.FillPath(Brushes.AliceBlue, graphicsPaths);
        }
    }
