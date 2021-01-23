    private void Application_Startup(object sender, StartupEventArgs e)
    {
        Resources.MergedDictionaries.Add(
            new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/WpfControlLibrary1;component/Dictionary1.xaml")
            });
    }
