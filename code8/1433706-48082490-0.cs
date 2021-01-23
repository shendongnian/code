    public class Startup
    {
        public void Configure(IApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(OnApplicationStarted);
        }
        public void OnApplicationStarted()
        {
            // Carry out your initialisation.
        }
    }
