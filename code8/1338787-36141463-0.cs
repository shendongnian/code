    public class Values
    {
        public Values(int value)
        { 
            this.SomeValue = value; 
        }
        
        public int SomeValue { get; }
    }
    
    // Register as
    container.RegisterSingleton<Values>(() => new Values(1));
