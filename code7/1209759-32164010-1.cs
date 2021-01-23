    public ActionResult SearchRegistration() {
      SearchParameterVM model = null;
      if (Request.Parameters["code"] != null) {
        model = new StuffRegisterSearchParameterVM();
        TryUpdateModel(model); // check return value
      }
    }
        
    
