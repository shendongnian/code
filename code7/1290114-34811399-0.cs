            Graphics g = e.Graphics;
            var path = new GraphicsPath();
            Rectangle outer = new Rectangle(100, 100, 300, 300);
            Rectangle inner = new Rectangle(150, 150, 200, 200);
            path.AddRectangle(outer);
            path.AddRectangle(inner);
            var brush = new SolidBrush(Color.Blue);
            g.FillPath(brush, path);
