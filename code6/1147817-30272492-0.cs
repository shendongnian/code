    public static class Configs
        {
            public static string Key1 {get;set;}
            public static string Key2 {get;set;}
          
        
      public static void Main()
      {
      	var info = typeof(Configs).GetProperties();
        var appSettings = ConfigurationManager.AppSettings;
        
        foreach(var s in info)
        {
            Console.WriteLine(s.Name);  
            foreach (var key in appSettings.AllKeys)
            {
                          if(key == s.Name)
                          {
                          	s = appSettings[key];
                          }
             }
        }
      }
    }
