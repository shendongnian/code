    var result = qrcoder.Write(inputData);
    using (var g = Graphics.FromImage(result))
    using (var font = new Font(FontFamily.GenericMonospace, 12))
    using (var brush = new SolidBrush(Color.Black))
    using(var format = new StringFormat(){Alignment = StringAlignment.Center})
    {
        int margin = 5, textHeight = 20;
        var rect = new RectangleF(margin, result.Height - textHeight,
                                  result.Width - 2 * margin, textHeight);
        g.DrawString(inputData, font, brush, rect, format);
    }
    result.Save(tempFileName);
