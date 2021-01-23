    public class SomeController 
    { 
        private ISomeRepository repository; 
        public SomeController(ISomeRepository repository) 
        { 
            this.repository = repository; 
        }
        // ... 
    }
