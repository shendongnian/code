    SolidBrush brush = new SolidBrush(Color.White);
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        SetPixel(brush, e.Graphics, 10, 10, Color.Red);
    }
    public void SetPixel(SolidBrush brush, Graphics graphics, int x, int y, Color color)
    {
        brush.Color = color;
        graphics.FillRectangle(brush, x, y, 1, 1);
    }
