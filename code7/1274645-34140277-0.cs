        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception exSvr = Server.GetLastError();
            if (exSvr == null)
                return;
            if (exSvr.Message == "The client disconnected.")
            {
                // I don't want to be notified everytime someone closes
                //   the browser mid-request.
                return;
            }
            if (exSvr is System.Threading.ThreadAbortException || exSvr.InnerException is System.Threading.ThreadAbortException || exSvr.Message.StartsWith("Thread was being aborted") || (exSvr.InnerException != null && exSvr.InnerException.Message.StartsWith("Thread was being aborted")))
            {
                // So we don't get notified everytime .NET kills a thread.
                // NOTE:  This error is how .NET kills a thread, and will happen every time we call Response.Redirect("", true)
                return;
            }
            ErrorHandler.SendServerErrMsg("Application Error", exSvr, HttpContext.Current);
        }
