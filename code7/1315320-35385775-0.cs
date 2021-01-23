    protected void Application_Error(object sender, EventArgs e)
            {
                // Response.TrySkipIisCustomErrors = true; I don't know if I will need it someday.
                var httpContext = ((HttpApplication)sender).Context;
                var exception = Server.GetLastError();
    
                ErrorSignal.FromCurrentContext().Raise(exception);
                Server.ClearError();
                Response.Clear();
                string relativePath = "~/Administration/Error/{0}";
                switch (Tools.GetHttpCode(exception))
                {
                    case (int)HttpStatusCode.BadRequest:
                        Server.TransferRequest(string.Format(relativePath, "BadRequest"));
                        break;
                    case (int)HttpStatusCode.Unauthorized:
                        Server.TransferRequest(string.Format(relativePath, "Unauthorized"));
                        break;
                    case (int)HttpStatusCode.Forbidden:
                        Server.TransferRequest(string.Format(relativePath, "Forbidden"));
                        break;
                    case (int)HttpStatusCode.NotFound:
                        Server.TransferRequest(string.Format(relativePath, "NotFound"));
                        break;
                    case (int)HttpStatusCode.InternalServerError:
                        Server.TransferRequest(string.Format(relativePath, "ServerError"));
                        break;
                    default:
                        Server.TransferRequest(string.Format(relativePath, "DefaultError"));
                        break;
                }
            }
