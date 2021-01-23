    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        FontFamily fontfamily = new FontFamily("Verdana");
        ComboBoxItem selectedFont = value as ComboBoxItem;
        if (selectedFont != null)
        {
            fontfamily = new FontFamily(selectedFont.Content.ToString());
        }
        return fontfamily;
    }
