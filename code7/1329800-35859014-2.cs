	public static class ViewsMapping
	{
		private static bool _isUIMappingRegistered = false;
		public static void Register()
		{
			if (!_isUIMappingRegistered)
			{
				ResourceDictionary MyResourceDictionary = new ResourceDictionary();
				MyResourceDictionary.Source = new Uri(".....", UriKind.Relative);
				Application.Current.Resources.MergedDictionaries.Add(MyResourceDictionary);
				_isUIMappingRegistered = true;
			}
		}
	}
		
