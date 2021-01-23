    private int CentimeterToPixel(double Centimeter)
    {
        double pixel = -1;
        using (Graphics g = this.CreateGraphics())
        {
            pixel = Centimeter * g.DpiY / 2.54d;
        }
        return (int)pixel;
    }
    
    // ...
    
    button.Width = CentimeterToPixel(2);
