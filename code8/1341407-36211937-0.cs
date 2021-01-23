     public static class Globals 
     {
         public static string Environment = MyApp.Properties.Settings.Default.Environment;
         public static string Server; 
         // rest of code
         public static void LoadEnvironment() 
         {
            switch (Environment)
            {
                case "development": 
                {
                    Server = "SQL1";
                    Username = "dev.user";
                    break;
                }
               // rest of code
            }
         }
    }
