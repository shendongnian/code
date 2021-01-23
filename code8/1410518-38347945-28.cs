    private void pic_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        for (int i = 0; i < Shapes.Count; i++)
        {
            var selected = (selectedIndex == i);
            using (var brush = new SolidBrush(selected ? selectedfillCOlor : fillColor))
                e.Graphics.FillEllipse(brush, Shapes[i]);
            using (var pen = new Pen(borderColor, borderWidth))
                e.Graphics.DrawEllipse(pen, Shapes[i]);
            TextRenderer.DrawText(e.Graphics, (i + 1).ToString(),
                    this.Font, Shapes[i], Color.Black,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
    }
