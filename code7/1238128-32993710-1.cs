    public Controller
    {
    
      private ISettings<FirstSettingsDto> _admin;
    
      public Controller(ISettings<FirstSettingsDto> admin = null)
      {
        _admin = admin ?? new GetSettingsConfiguration();
      }
    
      [HttpGet]
      public ActionResult GetInformation()
      {
          var config = _admin.GetSettings();
      }
    }
