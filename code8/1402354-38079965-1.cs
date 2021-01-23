    void hookUpTextBoxesIn(Control ctl, ScrollableControl sCtl)
    {
        foreach( Control c in ctl.Controls)
        {
            if (c.Controls.Count > 0) hookUpTextBoxesIn(c, sCtl);
            if (c is TextBox)
            {
                c.PreviewKeyDown += (s, e) =>
                    {
                        if (e.KeyData == Keys.PageDown) sCtl.AutoScrollPosition =
                            new Point(sCtl.AutoScrollPosition.X, 
                                     -sCtl.AutoScrollPosition.Y + 10);
                        if (e.KeyData == Keys.PageUp) sCtl.AutoScrollPosition =
                            new Point(sCtl.AutoScrollPosition.X,
                                     -sCtl.AutoScrollPosition.Y - 10);
                    };
            }
        }
    }
