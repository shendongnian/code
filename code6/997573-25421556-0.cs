      Application.Current.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);
      void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
      {
            string message = e.Exception.Message;
            ...
