    protected override void OnPaint(PaintEventArgs e)
    {
        // Measure text
        var textSize = TextRenderer.MeasureText(Text, Font);
        if (e.ClipRectangle.Width > textSize.Width)
        {
            var x = e.ClipRectangle.Width - textSize.Width;
            var rect = new Rectangle(x, 0, textSize.Width, textSize.Height);
            TextRenderer.DrawText(e.Graphics, Text, Font, rect, ForeColor, 
                TextFormatFlags.PathEllipsis);
            return;
        }
        TextRenderer.DrawText(e.Graphics, Text, Font, e.ClipRectangle, ForeColor, 
            TextFormatFlags.PathEllipsis);
    }
