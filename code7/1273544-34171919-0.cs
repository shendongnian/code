    using NLog;
    
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    
    public virtual ActionResult Edit(Client client)
    {
      try
      {
            // FORCE ERROR
            var x = 0;
    
            x /= x; /// error occur here
    
            return RedirectToAction(MVC.Client.Index()); /// no execution of this line
      }
      catch (Exception e)
      {
        _logger.Error("[Error in ClientController.Edit - id: " + client.Id + " - Error: " + e.Message + "]");
        /// add redirect link here 
         return RedirectToAction(MVC.Client.Error()); /// this is needed since the catch block execute mean no error at ASP.net level resulting no redirect to default error page
      }
    }
