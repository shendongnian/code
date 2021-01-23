    Point Latest { get; set; }
    List<Point> _points = new List<Point>(); 
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
       
        // Save the mouse coordinates
        Latest = new Point(e.X, e.Y);
        
        // Force to invalidate the form client area and immediately redraw itself. 
        Refresh();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        base.OnPaint(e);
        if (_points.Count > 0)
        {
            var pen = new Pen(Color.Navy);
            var pt = _points[0];
            for(var i=1; _points.Count > i; i++)
            {
                var next = _points[i];
                g.DrawLine(pen, pt, next);
                pt = next;
            }
            g.DrawLine(pen, pt, Latest);
        }
    }
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        Latest = new Point(e.X, e.Y);
        _points.Add(Latest);
        Refresh();
    }
