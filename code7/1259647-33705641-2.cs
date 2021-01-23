	public class MySessionStateProvider : SessionStateStoreProviderBase
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
			var tmp = inProcSessionStore.CreateNewStoreData(context, timeout);
			return tmp.Items.GetType() != typeof(SessionStateItemCollectionWrapper) ? new SessionStoreDataItemsChanger(tmp) : tmp;
		}
		//...
		//...
		public override SessionStateStoreData GetItem(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
		{
			var tmp = inProcSessionStore.GetItem(context, id, out locked, out lockAge, out lockId, out actions);
			if (tmp != null && tmp.Items.GetType() != typeof(SessionStateItemCollectionWrapper))
			{
				return new SessionStoreDataItemsChanger(tmp);
			}
			return tmp;
		}
		public override SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
		{
			var tmp = inProcSessionStore.GetItemExclusive(context, id, out locked, out lockAge, out lockId, out actions);
			if (tmp != null && tmp.Items.GetType() != typeof(SessionStateItemCollectionWrapper))
			{
				return new SessionStoreDataItemsChanger(tmp);
			}
			return tmp;
		}
		//...
		//...
	}
