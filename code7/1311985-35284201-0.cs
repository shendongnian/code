    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        Rectangle clipRectangle = e.ClipRectangle;
        graphics.DrawImage(this.image, 0, 0, this.Size.Width, this.Size.Height);
        // When hovered
        if (IsMouseOver)
        {
            Brush brush = new SolidBrush(this.selectedColor);
            graphics.FillRectangle(new SolidBrush(selectionColor), clipRectangle);
            graphics.DrawRectangle(new Pen(selectionBorderColor), clipRectangle.X, clipRectangle.Y, clipRectangle.Width - 1, clipRectangle.Height - 1);
        }
    }
