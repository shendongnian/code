            /// <summary>
            /// All Application Exception is Handled by this Event
            /// </summary>
            /// <param name="sender">Error Object</param>
            /// <param name="e">Error value</param>
            [HandleProcessCorruptedStateExceptions]
            [SecurityCritical]
            private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
            {
                try
                {
                    try
                    {
                        e.Handled = true;
                        WpfLogger.Log.Error(e.Exception.ToString());
                    }
                    catch (Exception)
                    {
                    }
                }
                catch (Exception)
                {
                }
            }
