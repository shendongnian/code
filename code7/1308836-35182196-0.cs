    void Application_Error(object sender, EventArgs e)
    { 
      Exception CurrentException = Server.GetLastError();
      Server.ClearError();
      if (CurrentException != null)
      {
        try
        {
            File.AppendAllText(Server.MapPath("HereAreErrors.txt"));
        }
        catch (Exception ex) { }
      }
    }
