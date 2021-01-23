    public class GUIThreadDispatcher {
            private static volatile GUIThreadDispatcher itsSingleton;
            private WeakReference itsDispatcher;
    
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
    
            public void Init(Control ctrl) {
                itsDispatcher = new WeakReference(ctrl);
            }
    
            public void Invoke(Action method) {
                ExecuteAction((Control ctrl) => DoInGuiThread(ctrl, method, forceBeginInvoke: false));
            }
    
            public void BeginInvoke(Action method) {
                ExecuteAction((Control ctrl) => DoInGuiThread(ctrl, method, forceBeginInvoke: true));
            }
    
            private void ExecuteAction(Action<Control> action) {
                if (itsDispatcher.IsAlive) {
                    var ctrl = itsDispatcher.Target as Control;
                    if (ctrl != null) {
                        action(ctrl);
                    }
                }
            }
    
            public static void DoInGuiThread(Control ctrl, Action action, bool forceBeginInvoke = false) {
                if (ctrl.InvokeRequired) {
                    if (forceBeginInvoke)
                        ctrl.BeginInvoke(action);
                    else
                        ctrl.Invoke(action);
                }
                else {
                    action();
                }
            }
        }
    }
