    RectangleF bounds = new RectangleF(x, y, width, height);
    StringFormat format = new StringFormat();
    format.Alignment = StringAlignment.Center ;
    format.LineAlignment = StringAlignment.Center ;
    graphicsObj.DrawText("Number", SystemFonts.Default, SystemBrushes.WindowText, bounds, format);
