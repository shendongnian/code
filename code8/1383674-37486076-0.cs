    // this can be serializable if needed
    public string color;
    // non-serializable
    public SolidColorBrush ItemBrush
    {
        get
        {
            return new SolidColorBrush(Windows.UI.Color.FromArgb(byte.Parse(color.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                                       byte.Parse(color.Substring(3, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(5, 2), System.Globalization.NumberStyles.HexNumber),
                                       byte.Parse(color.Substring(7, 2), System.Globalization.NumberStyles.HexNumber)));
        }
        set { color = value.Color.ToString(); }
    }
