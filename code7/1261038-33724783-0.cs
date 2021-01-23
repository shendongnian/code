    //Put it in the Global.asax.cs file
    
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                
                ScanFiles();
            }
    
            private void ScanFiles()
            {
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Images"));
                var folders = di.GetDirectories().ToList().Select(d => d.Name);
    
                var files = di.GetFiles();
                foreach (var file in files)
                {
                    var image = new Image { name = file.ToString() };
                    db.Images.Add(image);
                   
                    //Hopefully, you have called SaveChanges() , because it is not seen here but hopefully you have called it in the Add method
                }
            }
