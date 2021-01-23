        public void BeginInvoke(Action action)
        {
            if( Application.Current.Dispatcher.CheckAccess())                
                Application.Current.Dispatcher.BeginInvoke(action);
            else
            {
                action();
            }
        }
        public void Invoke(Action action)
        {
            if (Application.Current.Dispatcher.CheckAccess())
                Application.Current.Dispatcher.BeginInvoke(action);
            else
            {
                action();
            }
        }
    public static class PublicStaticFunctions
