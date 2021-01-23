        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                string redirectToPage;
                switch (httpException.GetHttpCode())
                {
                    // page not found
                    case 404:
                        redirectToPage = "(websitename)/PageNotFoundError.aspx";
                        break;
                    default:
                        redirectToPage = "(websitename)/GeneralError.aspx";
                        break;
                }
                Response.Redirect(redirectToPage);
            }
        }
