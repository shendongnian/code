    void constrain(Control ctl, Control view)
    {
        Rectangle pr = view.ClientRectangle;
        Rectangle cr = ctl.ClientRectangle;
        int x = Math.Min(0, Math.Max(ctl.Left, pr.Width - cr.Width));
        int y = Math.Min(0, Math.Max(ctl.Top, pr.Height - cr.Height));
        ctl.Location = new Point(x,y);
    }
