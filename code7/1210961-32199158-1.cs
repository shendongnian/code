     namespace MyApp.Resources
     {
        public static class Resource
        {
           private static ResourceManager manager;
           static Resource()
           {
              manager = new ResourceManager("MyApp.Resources", Assembly.GetAssembly(typeof(Resource));
           }
        }
        public static string GetString(string key, string culture)
        {
           return GetString(key, new CultureInfo(culture));
        }
        public static string GetString(string key, CultureInfo culture)
        {
           return manager.GetString(key, culture);
        }
     }
