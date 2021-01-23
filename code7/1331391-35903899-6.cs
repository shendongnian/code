     public class GUIThreadDispatcher {
            private static volatile GUIThreadDispatcher itsSingleton;
            private Dispatcher itsDispatcher;
    
            private GUIThreadDispatcher() { }
            public static GUIThreadDispatcher Instance
            {
                get
                {
                    if (itsSingleton == null)
                        itsSingleton = new GUIThreadDispatcher();
    
                    return itsSingleton;
                }
            }
    
            public void Init() {
                itsDispatcher = Dispatcher.CurrentDispatcher;
            }
    
            public object Invoke(Action method, DispatcherPriority priority = DispatcherPriority.Render, params object[] args) {
               return itsDispatcher.Invoke(method, priority, args);
            }
    
            public DispatcherOperation BeginInvoke(Action method, DispatcherPriority priority = DispatcherPriority.Render, params object[] args) {
                return itsDispatcher.BeginInvoke(method, priority, args);
            }
