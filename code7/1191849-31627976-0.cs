    int getFirstVisibleItem(ListView lv)
    {
        ListViewHitTestInfo HI;
        for (int i = 0; i < Math.Min(lv.ClientSize.Width, lv.ClientSize.Height); i += 3)
        {
            HI = lv.HitTest(i, i);
            if (HI.Item != null) return HI.Item.Index;
        }
        return -1;
    }
