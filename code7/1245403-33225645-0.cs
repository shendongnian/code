    public class FooOptions
    {
        public FooOptions()
        {
            MaintenanceInterval = TimeSpan.FromSeconds(30);
            MaximumIdleTime = TimeSpan.FromMinutes(5);
        }
        public TimeSpan MaintenanceInterval { get; set; }
        public TimeSpan MaximumIdleTime { get; set; }
        //etc...
    }
