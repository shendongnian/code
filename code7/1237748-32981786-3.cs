    private List<ImageFormat> GetValidImageFormats()
    {
        var t = typeof(ImageFormat);
        return ValidExtensions.Select(x =>
            (ImageFormat)t.GetProperty(x, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static)
                          .GetValue(null)).ToList();
    }
