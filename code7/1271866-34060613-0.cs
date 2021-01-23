    StringFormat format = new StringFormat()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
    };
    var p = new GraphicsPath();
    p.AddString(
        newText,
        Font.FontFamily,
        (int)Font.Style,
        Font.Size,
        ClientRectangle, // !!!
        format); // !!!
