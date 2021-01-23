            Resources.MergedDictionaries.Clear();
            var dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "de-DE":
                    dict.Source = new Uri("pack://application:,,,/Resources;component/StringResources.de-DE.xaml", UriKind.Absolute);
                    break;
                default:
                    dict.Source = new Uri("pack://application:,,,/Resources;component/StringResources.xaml", UriKind.Absolute);
                    break;
            }
            Resources.MergedDictionaries.Add(dict);
