    public class Service
    {
        // Injector method
        private IMyDataContext GetContext() {
            // Here is the main code
    
    #if TEST    // <-- In 'Test' configuration
                // we will use fake context
                return new FakeDataContext(); 
    #else
                // in any other case 
                // we will use real context
                return new RealDataContext(); 
    #endif
    
        }
    
        public int CountSomeEntites()
        {
           // the service works with interface and does know nothing
           // about the implementation
    
            using (IMyDataContext ctx = GetContext()) 
            {
                int result = ctx.SomeEntities.Count();
                return result;
            }
        }
    }
