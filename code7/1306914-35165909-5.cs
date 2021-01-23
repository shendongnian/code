            protected void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
            {
                FilterError404(e);
            }
            protected void ErrorMail_Filtering(object sender, ExceptionFilterEventArgs e)
            {
                FilterError404(e);
            }
            // Dismiss 404 errors for ELMAH
            private void FilterError404(ExceptionFilterEventArgs e)
            {
                if (e.Exception.GetBaseException() is HttpException)
                {
                    HttpException ex = (HttpException)e.Exception.GetBaseException();
                    if (ex.GetHttpCode() == 404)
                        e.Dismiss();
                }
            }
