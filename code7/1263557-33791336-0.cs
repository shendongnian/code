    public class EntityObject
    {
        public ILogger Logger { get; set; }
    
        public EntityObject(ILogger logger)
        {
            Logger = logger;
        }
    }
