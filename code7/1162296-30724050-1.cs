        void Application_Error(object sender, EventArgs e)
        {
            
            // Get the exception
            Exception exc = Server.GetLastError();
            // Do something with the exception, write it to the event log, save it to the db, email someone who cares etc
            // Clear the error
            Server.ClearError();
            // Redirect to a generic error page
            Response.Redirect("~/System/err.aspx");
                        
        }
