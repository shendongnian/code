    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        FontFamily fontfamily = new FontFamily("Verdana");
        ComboBoxItem selectedFont;
        if (value != null && (selectedFont = value as ComboBoxItem) != null)
        {
            fontfamily = new FontFamily(selectedFont.Content.ToString());
        }
        return fontfamily;
    }
