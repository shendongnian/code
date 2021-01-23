    Scan(
            scan => {
                scan.TheCallingAssembly();
                scan.Assembly("BusinessLayer");
                scan.Assembly("DataLayer");
                scan.WithDefaultConventions();
            });
    
