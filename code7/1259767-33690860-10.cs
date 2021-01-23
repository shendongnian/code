    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value != null)
        {
            System.Diagnostics.Debug.WriteLine(value.GetType());
            return value.ToString();
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("value is null");
            return null;
        }
    }
