	public class SessionStoreDataItemsInjecter : SessionStateStoreData
	{
		public SessionStoreDataItemsInjecter(SessionStateStoreData wrappedData)
			: base(new SessionStateItemCollectionWrapper(wrappedData.Items), wrappedData.StaticObjects, wrappedData.Timeout)
		{
		}
	}
