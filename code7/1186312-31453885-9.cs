    void theBoxCell_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        string t = theBoxCell.Items[e.Index].ToString();
        using (SolidBrush brush = new SolidBrush(
            (e.State & DrawItemState.Selected) != DrawItemState.None ?
                       Color.LightCyan : Color.LightGray))
            e.Graphics.FillRectangle(brush, e.Bounds);
        e.DrawFocusRectangle();
        e.Graphics.DrawString(t, Font, Brushes.DarkGoldenrod, e.Bounds.X + 6, e.Bounds.Y + 1);
    }
