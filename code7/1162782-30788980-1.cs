    class AppSettings
    {
       public string SomeSetting {get;set;}
    }
    var configuration = new Configuration().AddJsonFile("config.json");
    var opt = ConfigurationBinder.Bind<AppSettings>(configuration);
    opt.SomeSetting 
