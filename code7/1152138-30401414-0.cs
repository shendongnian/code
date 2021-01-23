    List<Rectangle> GetTabBounds(TabControl tab)
    {
        List<Rectangle> bounds = new List<Rectangle>();
        TabDrawMode tdm = tab.DrawMode;
        tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        DrawItemEventHandler mit = (sl, el) => bounds.Add(el.Bounds);
        tab.DrawItem += mit;
        tab.Refresh();
        tab.DrawItem -= mit;
        tab.DrawMode = tdm;
        tab.Invalidate();
        return bounds.OrderBy(r=>r.X).ToList();
    }
