    private void OnResize(object sender, EventArgs e)
    {
        Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        UpdateImage(e.Graphics);
    }
    private void UpdateImage(Graphics graphics)
    {
        var columns = 10;
        var rows = 8;
        var hueSteps = 360 / columns;
        var columnSteps = 1.0F / columns;
        var width = Width / columns;
        var height = Height / (rows + 1);
        for (int i = 0; i < columns; i++)
        {
            var gray = ColorExtensions.FromAhsb(255, 0, 0, columnSteps * i);
            using (var brush = new SolidBrush(gray))
            {
                graphics.FillRectangle(brush, width * i, 0, width, height);
            }
        }
        for (int i = 0; i < columns; i++)
        {
            for (int j = 1; j <= rows; j++)
            {
                var color = ColorExtensions.FromAhsb(255, hueSteps * i, 1, columnSteps * j);
                using (var brush = new SolidBrush(color))
                {
                    graphics.FillRectangle(brush, width * i, height * j, width, height);
                }
            }
        }
    }
