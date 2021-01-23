    public class EntityObject
    {
        public ILogger Logger { get; set; } //it is better by the way to convert this into a private field
    
        public EntityObject(ILogger logger)
        {
            Logger = logger;
        }
    }
