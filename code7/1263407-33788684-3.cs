    using System.Collections.Concurrent;
    public ConcurrentAccess<T>
    {
        private
        static
        readonly ConcurrentDictionary<int, data> dict =
        new ConcurrentDictionary<int, data>();
        //we do not need lock anymore
        public static bool TryAdd(int id, T data)
        {
            return dict.TryAdd(id , data);
            //you can test if id already exist
        }
        public static bool TryRemove(int id)
        {
            T t = default(T);
            return dict.TryRemove(id, out t);
        }
        
        
        public static bool TryInvokeAction(int id, Action<T> action)
        {
            bool rslt = false.
            T t = default(T);
            
            if ((rslt = dict.TryRemove(id, out t)))
            {
               
               //removed item
               action(t);
               //return item to dict
               dict.Add(t);
            }
            return rslt;
        }
    }
    //usage:
    ConcurrentAccess<string>.TryAdd(5, "add 5");
    ConcurrentAccess<string>.TryAdd(6, "add 6");
    ConcurrentAccess<string>.TryAdd(7, "add 7");
    ConcurrentAccess<string>.TryRemove(5);
    
    ConcurrentAccess<string>.TryInvokeAction(5, str =>
    {
        Console.WriteLine("data: {0}", str);
    }
