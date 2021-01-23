       private MyObject myObject;        
       private Object lockObject;        
       private MyObjectFactory factory;
       private bool initialized;
    
        public MyObject GetObject()
        {
          return LazyInitializer.EnsureInitialized(ref myObject, ref initialized, ref lockObject, factory.Create)
        }
