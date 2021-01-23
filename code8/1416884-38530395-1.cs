    public static class Caches
    {
        public static class For<T>
        {
            public static IDictionary<int,T> Cache{get;}=new Dictionary<int,T>(); 
        }
    
        public static Set<T>(int key,T value)=> For<T>.Cache[k]=v;
    }
    
    // and to use the dictionary
    public void DoStuff(int i, string value){
        Caches.For<string>.Cache[i]=value;
        // or if you define generic methods in Caches like Set 
        Caches.Set(i,value);
    }
