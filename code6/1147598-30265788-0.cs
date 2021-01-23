        static class UiUtils
        {
        static UiUtils()
        {
            Dispatcher = Application.Current == null
                ? null
                : Application.Current.Dispatcher;
        }
        public static Dispatcher Dispatcher { get; private set; }
        public static void InvokeMainThread(this Action action)
        {
            try
            {
                if (Dispatcher != null && !Dispatcher.CheckAccess())
                    Dispatcher.Invoke(action);
                else
                    action();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error invoking main thread: {0}", ex);
            }
        }
    }
