    public object Convert(object value, Type targetType, object parameter, string language)
        {
            string path = value as string;
            if (null != path)
                return Convert(path);
            else
                return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            PathGeometry geometry = value as PathGeometry;
            if (null != geometry)
                return ConvertBack(geometry);
            else
                return default(string);
        }
