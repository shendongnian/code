    foreach (var item in data)
    {
        y = y + 30;
        XRect snoColumnVal = new XRect(35, y, 60, 25);
        XRect snoStudentNameVal = new XRect(100, y, 250, 25);
        var brush = new XSolidBrush(XColor.FromArgb(255, item.R, item.G, item.B));
        gfx.DrawRectangle(XPens.Black, brush, snoColumnVal);
        textformater.DrawString(item.Text, font, XBrushes.Black, snoStudentNameVal);
    }
