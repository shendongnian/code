		ResourceDictionary MyResourceDictionary = new ResourceDictionary();
		MyResourceDictionary.Source = new Uri(ResourceDictionarypath, UriKind.Relative);
		if ((Application.Current != null) && (Application.Current.Resources != null))
		{
			Application.Current.Resources.MergedDictionaries.Add(MyResourceDictionary);
		}
