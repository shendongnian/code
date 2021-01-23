    protected override void OnPaintBackground(PaintEventArgs e)
    {
        using (var brush = new SolidBrush(Color.FromAgrb(50, 0, 0, 0))
        {
            e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }
    }
