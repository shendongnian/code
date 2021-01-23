    public Controller
    {
    
      private ISettings<FirstSettingsDto> _admin;
    
      public Controller(ISettings<FirstSettingsDto> admin)
      {
        _admin = admin;
      }
    
      [HttpGet]
      public ActionResult GetInformation()
      {
          var config = _admin.GetSettings();
      }
    }
