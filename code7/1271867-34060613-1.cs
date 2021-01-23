    StringFormat format = new StringFormat()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
    };
    float emSize = graphics.DpiY * Font.Size / 72;
    var p = new GraphicsPath();
    p.AddString(
        newText,
        Font.FontFamily,
        (int)Font.Style,
        emSize ,
        ClientRectangle, // !!!
        format); // !!!
