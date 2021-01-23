    public ActionResult SOmeAction()
    {
       //this refers to controller, GetCustomAttribute looks for attribute on controller
       //GetCustomAttribute is a 4.5 extension method
       var attrib = this.GetType().GetCustomAttribute<AuthorizeAttribute>();
       if (attrib != null)
       {
          var roles = attrib.Roles;
       }
    }
