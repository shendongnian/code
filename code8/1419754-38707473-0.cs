    public abstract class Operation
        {
            protected Logger logger;
    
            public Operation(Logger logger)
            {
                this.logger = logger;
            }
        }
    
    
    public class StocktakingOperation : Operation
        {
            public string test = DateTime.Now.ToString();
    
            public StocktakingOperation(Logger logger)
                : base(logger)
            {
    
            }
        }
