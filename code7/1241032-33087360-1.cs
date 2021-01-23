    protected override void OnPaintBackground(PaintEventArgs pe) {
        base.OnPaintBackground(pe);
        // Inner Border
        using (var pen = new Pen(_InnerBorderColor))
            pe.Graphics.DrawRectangle(pen, 1, 1, ClientSize.Width - 3, ClientSize.Height - 3);
        // Main Border
        using (var pen = new Pen(_BorderColor))
            pe.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
    }
