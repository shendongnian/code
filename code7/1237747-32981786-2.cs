    private List<ImageFormat> GetValidImageFormats()
    {
        var t = typeof(ImageFormat);
        return ValidExtensions.Select(x =>
            (ImageFormat)t.GetProperty(x.Substring(0, 1).ToUpper() + x.Substring(1))
                          .GetValue(null)).ToList();
    }
