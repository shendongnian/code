    LinearGradientBrush linearGradientBrush =
       new LinearGradientBrush(panel4.ClientRectangle, Color.Red, Color.Yellow, 45);
    ColorBlend cblend = new ColorBlend(3);
    cblend.Colors = new Color[3]  { Color.Red, Color.Yellow, Color.Green };
    cblend.Positions = new float[3] { 0f, 0.5f, 1f };
    linearGradientBrush.InterpolationColors = cblend;
    e.Graphics.FillRectangle(linearGradientBrush, panel4.ClientRectangle);
