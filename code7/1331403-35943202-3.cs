       public class GUIThreadDispatcher {
        private static volatile GUIThreadDispatcher itsSingleton;
        private SynchronizationContext itsSyncContext;
        private GUIThreadDispatcher() {}
        /// <summary>
        /// This needs to be called on the GUI Thread somewhere
        /// </summary>
        public void Init() {
            itsSyncContext = AsyncOperationManager.SynchronizationContext;
        }
        
        public static GUIThreadDispatcher Instance
        {
            get
            {
                if (itsSingleton == null)
                    itsSingleton = new GUIThreadDispatcher();
                return itsSingleton;
            }
        }
        public void Invoke(Action method) {
            itsSyncContext.Send((state) => { method(); }, null);
        }
        public void BeginInvoke(Action method) {
            itsSyncContext.Post((state) => { method(); }, null);
        }
    }
