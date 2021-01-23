        void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            AppEventSource.Log.Error(HttpContext.Current.Request.RawUrl, GetUserName(HttpContext.Current.User), exception.Message, HttpContext.Current.Request.UserHostAddress);
            Server.ClearError();
            if (exception is UnauthorizedAccessException)
            {
                Response.Redirect("~/Error/401");
            }
            else {
                //generic error
                Response.Redirect("~/Error");
            }
        }
