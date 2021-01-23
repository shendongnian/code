    private static void SetStyle(bool useInternal)
    {
        var res = Application.Current.Resources;
        res.MergedDictionaries.Clear();
        if (useInternal)
            res.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/Internal.xaml")
            });
        else
            res.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/External;component/External.xaml")
            });
    }
