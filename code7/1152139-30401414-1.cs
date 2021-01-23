    SortedDictionary<int, Rectangle> GetTabBounds(TabControl tab)
    {
        SortedDictionary<int, Rectangle> bounds = new SortedDictionary<int, Rectangle>();
        TabDrawMode tdm = tab.DrawMode;
        tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        DrawItemEventHandler mit = (sl, el) => bounds.Add(el.Index, el.Bounds);
        tab.DrawItem += mit;
        tab.Refresh();
        tab.DrawItem -= mit;
        tab.DrawMode = tdm;
        tab.Invalidate();
        return bounds;
    }
