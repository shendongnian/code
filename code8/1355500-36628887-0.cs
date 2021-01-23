    public void int Main(string[] args)
    {
        // Validate the args are valid (not shown).
        var config = new AppConfig();
        config.Value1 = args[0];
        config.Value2 = int.Parse(args[1]);
        // etc....
    }
    public class MyService()
    {
        private AppConfig _config;
        public MyService(AppConfig config)
        {
            this._config = config;
        }
    }
