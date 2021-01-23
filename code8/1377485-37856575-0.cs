    using System.Windows;
    using System.Windows.Media;
    public void DrawTextTest(DrawingContext dc) {
        var y = 100.0;
        foreach (var align in new TextAlignment[]{
            TextAlignment.Left, TextAlignment.Center, TextAlignment.Right}) {
            foreach (var width in new double[] { 0.0, 150.0 }) {
                DrawText(dc, new Point(400, y), align, width);
                y += 25.0;
            }
            y += 45.0;
        }
    }
    private void DrawText(DrawingContext dc, Point origin,
        TextAlignment align, double maxTextWidth) {
        var f = new FormattedText(
            "This is a text with TextAlignment = " + align.ToString()
                + " and MaxTextWidth = " + maxTextWidth.ToString() + ".",
            System.Globalization.CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface("Arial"), 12.0, Brushes.Black
        ) {
            TextAlignment = align,
            MaxTextWidth = maxTextWidth
        };
        dc.DrawEllipse(Brushes.Blue, null, origin, 1.0, 1.0);
        var correctionX = -maxTextWidth * (align == TextAlignment.Right ? 1.0
            : (align == TextAlignment.Center ? 0.5 : 0.0));
        origin.Offset(correctionX, 0.0);
        dc.DrawEllipse(Brushes.Red, null, origin, 1.0, 1.0);
        dc.DrawText(f, origin);
    }
