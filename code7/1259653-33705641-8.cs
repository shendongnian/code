    abstract class InProcSessionStateInjected<T> : SessionStateStoreProviderBase where T : ISessionStateItemCollectionWrapper, new()
    {
        private SessionStateStoreProviderBase inProcSessionStore;
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            var inProcSessionStoreType = typeof(SessionStateStoreProviderBase).Assembly.GetType("System.Web.SessionState.InProcSessionStateStore");
            inProcSessionStore = (SessionStateStoreProviderBase)Activator.CreateInstance(inProcSessionStoreType);
            inProcSessionStore.Initialize(name, config);
        }
        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            var sessionStateStoreData = inProcSessionStore.CreateNewStoreData(context, timeout);
            return sessionStateStoreData.Items.GetType() != typeof(T) ? new SessionStoreDataItemsInjector<T>(sessionStateStoreData) : sessionStateStoreData;
        }
        public override SessionStateStoreData GetItem(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            var sessionStateStoreData = inProcSessionStore.GetItem(context, id, out locked, out lockAge, out lockId, out actions);
            if (sessionStateStoreData != null && sessionStateStoreData.Items.GetType() != typeof(T))
            {
                return new SessionStoreDataItemsInjector<T>(sessionStateStoreData);
            }
            return sessionStateStoreData;
        }
        public override SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            var sessionStateStoreData = inProcSessionStore.GetItemExclusive(context, id, out locked, out lockAge, out lockId, out actions);
            if (sessionStateStoreData != null && sessionStateStoreData.Items.GetType() != typeof(T))
            {
                return new SessionStoreDataItemsInjector<T>(sessionStateStoreData);
            }
            return sessionStateStoreData;
        }
