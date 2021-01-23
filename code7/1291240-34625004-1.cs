    private void DrawEllipseInt(Graphics g)
    {
        // Create pen.
        Pen blackPen = new Pen(Color.Black, 3);
    
        // Create location and size of ellipse.
        int x = 0;
        int y = 0;
        int width = 200;
        int height = 100;
    
        // Draw ellipse to screen.
        g.DrawEllipse(blackPen, x, y, width, height);
    }
