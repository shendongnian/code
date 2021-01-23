    protected void Page_Load(object sender, EventArgs e)
      {
                    LoadError(Server.GetLastError());
      }
        
    protected void LoadError(Exception objError)
      {
                    Exception innerException = null;           
                    if (objError != null)
                    {
                        if (objError.InnerException != null)
                        {
                            innerException = objError.InnerException;
                        }
                    }
     }
