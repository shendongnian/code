    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (_lastPosition != Point.Empty)
        {
            var currentPosition = Cursor.Position;
            var oradius = Math.Sqrt(((_lastPosition.X - currentPosition.X) ^ 2) + ((_lastPosition.Y - currentPosition.Y) ^ 2));
            var radius = Convert.ToInt32(oradius);
            using (var g = this.CreateGraphics())
            {
                var arg = new PaintEventArgs(g, new Rectangle());
                DrawCircle(arg, currentPosition, radius, radius);
            }
            _lastPosition = Point.Empty;
        }
        else
        {
            _lastPosition = Cursor.Position;
        }
            
    }
    private void DrawCircle(PaintEventArgs e, Point position, int width, int height)
    {
        using (var pen = new System.Drawing.Pen(System.Drawing.Color.Red, 3))
        {
            e.Graphics.DrawEllipse(pen, position.X - width / 2, position.Y - height / 2, width, height);
        }
    }
