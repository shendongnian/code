    /// <summary>
    /// Dynamically set WPF Window Theme resource dictionary
    /// </summary>
    /// <param name="ThemeCode">bool</param>
    private void SelectGreenTheme()
    {
        // prefix to the relative Uri for Theme resources (xaml file)
        string _prefix = String.Concat(typeof(App).Namespace, ";component/");
    
        // clear all resource dictionaries in this window
        // Note: on app level use: Application.Current.Resources.MergedDictionaries.Clear();
        this.Resources.MergedDictionaries.Clear();
    
        // add resource theme dictionary to this window
        // Note: on app level use: Application.Current.Resources.MergedDictionaries.Add
        this.Resources.MergedDictionaries.Add
        (
            new ResourceDictionary { Source = new Uri(String.Concat(_prefix + "Themes\Green.xaml, UriKind.Relative) }
        );
    }
