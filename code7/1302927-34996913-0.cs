    using (GraphicsPath graphicsPath = new GraphicsPath())
    {
        graphicsPath.AddString(
            "sample text",
            new FontFamily("Times New Roman"),
            (int)FontStyle.Bold,
            graphics.DpiY * 12 / 72,
            new PointF(0,0),
            StringFormat.GenericDefault
        );
    
        Matrix matrix = new Matrix();
        matrix.Shear(10, 0);
        graphics.MultiplyTransform(matrix);
    
        graphics.FillPath(new SolidBrush(Color.Red), graphicsPath);
    }
