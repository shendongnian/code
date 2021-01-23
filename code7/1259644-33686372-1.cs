    public class MySessionStateProvider : System.Web.SessionState.SessionStateStoreProviderBase {
        private readonly SessionStateStoreProviderBase InProcSessionStore;
        public MySessionStateProvider() {
            var inProcSessionStoreType = typeof(System.Web.SessionState.SessionStateStoreProviderBase).Assembly.GetType("System.Web.SessionState.InProcSessionStateStore");
            InProcSessionStore = (System.Web.SessionState.SessionStateStoreProviderBase)Activator.CreateInstance(inProcSessionStoreType);
            InProcSessionStore.Initialize(null, null);
        }
        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout) {
            return InProcSessionStore.CreateNewStoreData(context, timeout);
        }
        public override void CreateUninitializedItem(HttpContext context, string id, int timeout) {
            InProcSessionStore.CreateUninitializedItem(context, id, timeout);
        }
        public override void Dispose() {
            InProcSessionStore.Dispose();
        }
        //... Implement the rest of the method in the same manner.        
        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback) {
            return InProcSessionStore.SetItemExpireCallback(expireCallback);
        }
    }
