    class SessionStoreDataItemsInjector<T> : SessionStateStoreData where T:ISessionStateItemCollectionWrapper, new()
    {
        public SessionStoreDataItemsInjector(SessionStateStoreData wrappedData)
            : base(new T()
            {
                WrappedCollection = wrappedData.Items
            }, wrappedData.StaticObjects, wrappedData.Timeout)
        {
        }
    }
