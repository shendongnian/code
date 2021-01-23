    Scan(scan =>
         {
                    // YourProject.Service: The project that contains IProductService
                    scan.Assembly("YourProject.Service");
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
         });
