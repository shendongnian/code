    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var imageDetail = (ImageDetail)value;
        var configs = ServiceLocator.Current.GetInstance<IRuntimeConfigurations>();
        var path = Path.Combine(configs.rootImagePath, imageDetail.fileName);
        var uri = new Uri(path, UriKind.RelativeOrAbsolute);
        return new BitmapImage(uri);
    }
