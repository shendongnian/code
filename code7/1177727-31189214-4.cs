    void makeTabPanel(TabControl tab)
    {
        tp = new Panel();
        tp.Size = new Size(tab.Width, tab.ItemSize.Height);
        tp.Paint += tp_Paint;
        tp.MouseClick += tp_MouseClick;
        tp.Location =  tab.Location;
        tab.Parent.Controls.Add(tp);
        int tabs = tabControl1.TabPages.Count;
        float w = tabControl1.Width / tabs;
        float h = tp.Size.Height;
        float y0 = 0;
        float y1 = h / 2f;
        float y2 = h;
        float d = 5;          //  <--- this is the gap
        float e = 8;          //   <- this is the extrusion
        float w1 = w - d;
        tabAreas = new List<GraphicsPath>();
        for (int t = 0; t < tabs; t++)
        {
            int t1 = t + 1;
            float e1 = t == 0 ? 0 : e;    // corrections for start and end..
            float e2 = t == tabs - 1 ? 0 : e;
            float e3 = t == tabs - 1 ? d : 0;
            List<PointF> points = new List<PointF>();
            points.Add(new PointF(t * w, y0));
            points.Add(new PointF(t1 * w - d + e3, y0));
            points.Add(new PointF(t1 * w -d + e2 + e3, y1));
            points.Add(new PointF(t1 * w- d + e3, y2));
            points.Add(new PointF(t * w, y2));
            points.Add(new PointF(t * w + e1, y1));
            GraphicsPath gp = new GraphicsPath(FillMode.Alternate);
            gp.AddPolygon(points.ToArray());
            tabAreas.Add(gp);
        }
    }
