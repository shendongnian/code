    public static Size GetCurrentDisplaySize() {
        var displayInformation = DisplayInformation.GetForCurrentView();
        TypeInfo t = typeof(DisplayInformation).GetTypeInfo();
        var props = t.DeclaredProperties.Where(x => x.Name.StartsWith("Screen") && x.Name.EndsWith("InRawPixels")).ToArray();
        var w = props.Where(x => x.Name.Contains("Width")).First().GetValue(displayInformation);
        var h = props.Where(x => x.Name.Contains("Height")).First().GetValue(displayInformation);
        var size = new Size(System.Convert.ToDouble(w), System.Convert.ToDouble(h));
        switch (displayInformation.CurrentOrientation) {
        case DisplayOrientations.Landscape:
        case DisplayOrientations.LandscapeFlipped:
            size = new Size(Math.Max(size.Width, size.Height), Math.Min(size.Width, size.Height));
            break;
        case DisplayOrientations.Portrait:
        case DisplayOrientations.PortraitFlipped:
            size = new Size(Math.Min(size.Width, size.Height), Math.Max(size.Width, size.Height));
            break;
        }
        return size;
    }
