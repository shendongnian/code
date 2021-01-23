    if (AppDomain.CurrentDomain != null) {
       AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }
    
    if (Dispatcher.CurrentDispatcher != null) {
       Dispatcher.CurrentDispatcher.UnhandledException += CurrentDispatcher_UnhandledException;
    }
    
     static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
       // Do something with the exception in e.ExceptionObject
     }
    
     static void CurrentDispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
       // Do something with the exception in e.Exception
     }
