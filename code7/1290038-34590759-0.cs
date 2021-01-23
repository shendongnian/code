    public class UIHelper
    {
        private delegate void VoidHandler();
    
        public static void DoEvents()
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new VoidHandler(delegate { }));
        }
    }
