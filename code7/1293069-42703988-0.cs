	protected void YourOjbectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                if (e.Exception.InnerException is YourException)
                {
                    e.ExceptionHandled = true;
                    lblErrorMessage.Text = e.Exception.InnerException.Message;
                }
            }
        }
