    void RecalcTextPos()
    {
        if (this.IsDisposed == true)
            return;
        if (string.IsNullOrEmpty(base.Text))
            return;
        using (var graphics = Graphics.FromHwnd(this.Handle))
        {
            TextSize = graphics.MeasureString(base.Text, this.Font);
            TextPos.X = (this.Width / 2) - (TextSize.Width / 2);
            TextPos.Y = (this.Height / 2) - (TextSize.Height / 2);
        }
    }
