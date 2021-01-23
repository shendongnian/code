    static bool _privateFontsInstalled;
    
    private static void LoadPrivateFonts()
    {
        if (!_privateFontsInstalled)
        {
            try
            {
                Uri uri = new Uri("pack://application:,,,/");
                PdfSharp.Drawing.XPrivateFontCollection.Add(uri, "...");
                PdfSharp.Drawing.XPrivateFontCollection.Add(uri, "...");
                PdfSharp.Drawing.XPrivateFontCollection.Add(uri, "...");
    
                _privateFontsInstalled = true;
            }
            catch
            {
                Debug.Assert(false);
            }
        }
    }
