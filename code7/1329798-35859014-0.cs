		<ResourceDictionary .....
							xmlns:views="clr-namespace:...."
							xmlns:viewModels="clr-namespace:...."
							>
							
			<DataTemplate DataType="{x:Type viewModels:viewModels1}">
				<views:view1 />
			</DataTemplate>
			
			<DataTemplate DataType="{x:Type viewModels:viewModels2}">
				<views:view2 />
			</DataTemplate>
			
			...
			
		</ResourceDictionary>
		
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
		
