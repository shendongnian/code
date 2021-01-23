        // prefix to the relative Uri for resource (xaml file)
        string _prefix = String.Concat(typeof(App).Namespace, ";component/");
        // clear all resource dictionaries
        this.Resources.MergedDictionaries.Clear();
        // add resource theme dictionary
        this.Resources.MergedDictionaries.Add
        (
            new ResourceDictionary { Source = new Uri(String.Concat(_prefix + "Languages/English.xaml", UriKind.Relative) }
        );
