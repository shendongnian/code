    public class CustomObject 
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    
    /* ... */
    var objectKeys = configuration.Get("CustomObjectKeys").Trim().Split(',');
    var objects = objectKeys.ToDictionary(x => x, x => ConfigurationBinder.Bind<CustomObject>(configuration.GetConfigurationSection($"CustomObjects:{x}")));
