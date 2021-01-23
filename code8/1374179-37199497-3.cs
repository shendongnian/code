    public static class LibSettings
    {
        public static readonly Action<string> TheAction{ get; private set; }
        static LibSettings()
        {
            var action = ConfigurationManager.AppSettings["libAction"];
            switch(action)
            {
               case "console":
                   TheAction = ConsoleAction;
                   break;
               case "web":
                   TheAction = WebAction;
                   break;
               //And as many as you need...
            }
        }
        private static void ConsoleAction(string Parameter)
        {
           //Whatever it does...
        }
        private static void WebAction(string Parameter)
        {
           //Whatever it does...
        }
    }
