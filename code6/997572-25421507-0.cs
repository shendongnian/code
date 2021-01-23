        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);
		// Catch-all exception handler
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
            if (e.Exception != null)
            {
               //do somethine
            }
            if (e.Exception.InnerException != null)
            {
                //do logging?
            }
            //do logging?
        }
		// Catch-all exception handler
		private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
            if (e.ExceptionObject != null)
            {
                if (e.ExceptionObject is Exception)
                {
                    //do logging?
                }
            }
            //do logging?
        }
