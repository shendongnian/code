    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    var size = e.Graphics.MeasureString(
        item.Text, 
        aFont, 
        new Point(1,1), 
        StringFormat.GenericTypographic
        );
