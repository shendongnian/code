    public static class ControExtensions
      {
        public static void InvokeOnMainThread(this Control control, Action method)
        {
          if (method == null) throw new ArgumentNullException("method");
          if (!control.Dispatcher.CheckAccess()) {
            Application.Current.Dispatcher.BeginInvoke(method);
            return;
          }
    
          method();
        }
      }
