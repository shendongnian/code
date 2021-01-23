    var themeDict = new ResourceDictionary();
    var uriPath = string.Format("/{0};component/DarkTheme.xaml", 
    Assembly.GetEntryAssembly().GetName().Name);
    var uri = new Uri(uriPath, UriKind.RelativeOrAbsolute);
    themeDict.Source = uri;        
    Application.Current.Resources.MergedDictionaries.Add(themeDict);
