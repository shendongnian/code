    private string GetAssemblyName()
    {
        try { return Assembly.GetExecutingAssembly().FullName.Split(',')[0]; }
        catch { throw; }
    }
    private BitmapImage GetEmbeddedBitmapImage(string pathImageFileEmbedded)
    {
        try
        {
            // compose full path to embedded resource file
            string _fullPath = String.Concat(String.Concat(GetAssemblyName(), "."), pathImageFileEmbedded);
            BitmapImage _bmpImage = new BitmapImage();
            _bmpImage.BeginInit();
            _bmpImage.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(_fullPath);
            _bmpImage.EndInit();
            return _bmpImage;
        }
        catch { throw; }
        finally { }
    }
