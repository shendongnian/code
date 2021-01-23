    protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            ViewEngines.Engines.Clear();
            var razorEngine = new RazorViewEngine();
            razorEngine.MasterLocationFormats = razorEngine.MasterLocationFormats
                  .Concat(new[] {
          "~/Areas/MVC/{0}.cshtml"
                  }).ToArray();
            razorEngine.PartialViewLocationFormats = razorEngine.PartialViewLocationFormats
                  .Concat(new[] {
          "~/Areas/MVC/Views/{1}/{0}.cshtml",
          "~/Areas/MVC/Views{0}.cshtml",          
                  }).ToArray();
            ViewEngines.Engines.Add(razorEngine);
        }
