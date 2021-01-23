	public static class HandyControllerFunctions
	{
		public static object GetMasterObject(View view)
		{
			var propertyCollectionSource = (view as ListView)?.CollectionSource as PropertyCollectionSource;
			return propertyCollectionSource?.MasterObject ;
		}
	}
