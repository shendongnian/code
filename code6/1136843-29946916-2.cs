    var result = qrcoder.Write(inputData);
    int textWidth = 200, textHeight = 20;
    // creating new bitmap having imcreased width
    var img = new Bitmap(result.Width + textWidth, result.Height);
    using (var g = Graphics.FromImage(img))
    using (var font = new Font(FontFamily.GenericMonospace, 12))
    using (var brush = new SolidBrush(Color.Black))
    using (var bgBrush = new SolidBrush(Color.White))
    using (var format = new StringFormat() { Alignment = StringAlignment.Near })
    {
        // filling background with white color
        g.FillRectangle(bgBrush, 0, 0, img.Width, img.Height);
        // drawing your generated image over new one
        g.DrawImage(result, new Point(0,0));
        // drawing text
        g.DrawString(inputData, font, brush,  result.Width, (result.Height - textHeight) / 2, format);
    }
    img.Save(tempFileName);
