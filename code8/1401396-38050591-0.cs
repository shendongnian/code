    void Application_Error(object sender, EventArgs e)
    {
        string sourcepath = System.IO.Path.GetFileName(Request.Path);
        if (string.Compare(System.IO.Path.GetFileName(Request.Path), "vendorMassUpload.aspx", StringComparison.OrdinalIgnoreCase) == 0)
        {
            System.Exception lastException = Server.GetLastError();
            HttpException httpException = (HttpException)lastException;
            int httpCode = httpException.GetHttpCode();
            int errorCode = httpException.ErrorCode;
    
            // check if returned exception contains "exceed"
            if (lastException != null && lastException is HttpException && lastException.Message.Contains("exceed"))
            {
                Server.ClearError();
                // redirect to custom error page
                Response.Redirect("~/vendorManagement/vendorMassUpload.aspx?fileTooLarge=true");
            }
        }
    }
