    void DrawGrid(Graphics G, int ox, int oy, 
                  int major, int medium, int minor, Color c1, Color c2, Color c3)
    {
        using (Pen pen1 = new Pen(c1, 1f))
        using (Pen pen2 = new Pen(c2, 1f))
        using (Pen pen3 = new Pen(c3, 1f))
        {
            pen2.DashStyle = DashStyle.Dash;
            pen3.DashStyle = DashStyle.Dot;
            for (int x = ox; x < G.VisibleClipBounds.Width; x += major)
                G.DrawLine(pen1, x, 0, x, G.VisibleClipBounds.Height);
            for (int y = oy; y < G.VisibleClipBounds.Height; y += major)
                G.DrawLine(pen1, 0, y, G.VisibleClipBounds.Width, y);
            for (int x = ox; x < G.VisibleClipBounds.Width; x += medium)
                G.DrawLine(pen2, x, 0, x, G.VisibleClipBounds.Height);
            for (int y = oy; y < G.VisibleClipBounds.Height; y += medium)
                G.DrawLine(pen2, 0, y, G.VisibleClipBounds.Width, y); 
                
            for (int x = ox; x < G.VisibleClipBounds.Width; x += minor)
                G.DrawLine(pen3, x, 0, x, G.VisibleClipBounds.Height);
            for (int y = oy; y < G.VisibleClipBounds.Height; y += minor)
                G.DrawLine(pen3, 0, y, G.VisibleClipBounds.Width, y);
        }
    }
