    var image = new Bitmap(1000, 500);
    
    var g = Graphics.FromImage(image);
    g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 1000, 500);
    
    var stringFormat = new StringFormat(StringFormat.GenericTypographic) {
        Trimming = StringTrimming.None,
        FormatFlags = StringFormatFlags.MeasureTrailingSpaces,
        Alignment = StringAlignment.Near
    };
    
    var font = new Font(new System.Drawing.FontFamily("Times New Roman"), 12.0f);
    
    var point = new PointF { X = 10, Y = 10 };
    
    var offset = g.MeasureString(" ", font, point, stringFormat);
    
    SizeF[] outputs = new SizeF[7];
    outputs[0] = g.MeasureString("T", font, point, stringFormat);
    outputs[1] = g.MeasureString("e", font, point, stringFormat);
    outputs[2] = g.MeasureString("s", font, point, stringFormat);
    outputs[3] = g.MeasureString("t", font, point, stringFormat);
    outputs[4] = g.MeasureString("S", font, point, stringFormat);
    outputs[5] = g.MeasureString("t", font, point, stringFormat);
    outputs[6] = g.MeasureString("r", font, point, stringFormat);
    
    g.DrawString("TestStr", font, System.Drawing.Brushes.Red, new PointF { X = 10, Y = 10 }, stringFormat);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 0), 10.0f, outputs[0].Width, outputs[0].Height);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 1), 10.0f, outputs[1].Width, outputs[1].Height);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 2), 10.0f, outputs[2].Width, outputs[2].Height);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 3), 10.0f, outputs[3].Width, outputs[3].Height);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 4), 10.0f, outputs[4].Width, outputs[4].Height);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 5), 10.0f, outputs[5].Width, outputs[5].Height);
    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Green, 1.0f), GetOutputPositionX(outputs, 6), 10.0f, outputs[6].Width, outputs[6].Height);
    
    
    private float GetOutputPositionX(SizeF[] outputs, int p)
    {
    return 10.0f + outputs.Where((s, i) => i < p).Sum(x => x.Width);
    }
