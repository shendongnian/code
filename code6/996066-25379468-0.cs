    protected override void OnPaint(PaintEventArgs e)
    {
        graphics = e.Graphics;
        if (mouseDown)//<--Here
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //DrawRectangle(graphics);
            //DrawEllipse(graphics);
            DrawLine(graphics);
        }
    }
