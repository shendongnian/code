    private bool _doCustomDrawing = false;
    
    private void drawPanel_Paint(object sender, PaintEventArgs e)
    {
        if (_doCustomDrawing)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            Size size = drawPanel.ClientSize;
            Rectangle bounds = drawPanel.ClientRectangle;
            bounds.Inflate(-10, -10);
            g.FillEllipse(Brushes.LightGreen, bounds);
            g.DrawEllipse(Pens.Black, bounds);
        }
    }
    
    private void drawButton_Click(object sender, EventArgs e)
    {
        _doCustomDrawing = true;
        drawPanel.Invalidate();
    }
    
    private void drawPanel_Resize(object sender, EventArgs e)
    {
        drawPanel.Invalidate();
    }
