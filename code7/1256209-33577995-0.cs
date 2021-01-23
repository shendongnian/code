    string[] fonts = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();
    foreach (string font in fonts)
    {
        Debug.WriteLine(string.Format("Font: {0}", font));
    }
