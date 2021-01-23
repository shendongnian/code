    // a variable at class level:
    VScrollBar vScroll = null;
    // move into negative for testing:
    pictureBox1.Top = -15;
    // now check to see if we need a VScrollBar
    scrollCheck();
    void scrollCheck()
    {
        if (pictureBox1.Top < 0)
        {
            if (vScroll == null )
            { vScroll = new VScrollBar(); vScroll.Parent = panel1.Parent;
            vScroll.Scroll += vScroll_Scroll; vScroll.BringToFront();
            }
            vScroll.Location = new Point(panel1.Right - vScroll.Width - 2, panel1.Top + 1);
            vScroll.Height = panel1.ClientSize.Height - 2;
            vScroll.Value = vScroll.Maximum;
            vScroll.Show();
            }
        else
        { vScroll.Hide(); }
    }
    void vScroll_Scroll(object sender, ScrollEventArgs e)
    {
        int delta = e.NewValue - e.OldValue;
        if (delta < 0)
        {
            pictureBox1.Top = 0;
            scrollCheck();
        }
    }
