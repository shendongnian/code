	public class SessionStoreDataItemsInjector : SessionStateStoreData
	{
		public SessionStoreDataItemsInjector(SessionStateStoreData wrappedData)
			: base(new SessionStateItemCollectionWrapper(wrappedData.Items), wrappedData.StaticObjects, wrappedData.Timeout)
		{
		}
	}
