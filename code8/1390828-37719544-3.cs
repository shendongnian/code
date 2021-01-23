    public abstract class EvoObjectCollector<T> { 
    
        protected List<T> collection; 
    
        // Instead of the startYear and the endYear a CollectionContext could be added
        public abstract void Collect(int startYear, int endYear); 
    
        public List<T> GetCurrentCollection() { 
            return collection; 
        } 
    } 
    
    public AuthorCollector : EvoObjectCollector<Author> { 
    
        public AuthorCollector(int startYear, int endYear) { 
            Collect(startYear, endYear); 
        } 
    
        public void Collect(int startYear, int endYear) { 
            // Collect the collection 
            collection = ... 
        } 
    }
