    private int x;
    private int y;
    private int width;
    private int height;
    private SomeForm()
    {
        // Initialize ellipse position and size with some values
        ...
    }
    private void btnIncreaseWidth_Click(object sender, EventArgs e)
    {
        width += 5; // Increase width by 5 pixels
        Invalidate();
    }
    private void btnDecreaseWidth_Click(object sender, EventArgs e)
    {
        width -= 5; // Decrease width by 5 pixels
        Invalidate();
    }
    private void btnIncreaseHeight_Click(object sender, EventArgs e)
    {
        height += 5; // Increase height by 5 pixels
        Invalidate();
    }
    private void btnDecreaseHeight_Click(object sender, EventArgs e)
    {
        height -= 5; // Decrease height by 5 pixels
        Invalidate();
    }
    private void SomeForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.FillEllipse(new SolidBrush(colorDlg.Color), x, y, width, height);
    }
    
