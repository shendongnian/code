    class classTwo : IEnumerator {
 
        public object Current {get;}
        public bool MoveNext() { ... }
        public void Reset() { ... }
    
        ...
        public IEnumerator GetEnumerator() 
        {
            return this; 
        }
    }
