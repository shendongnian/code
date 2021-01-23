    namespace com.example // Assembly = com.example
    {
    
        public class Foo
        {
            public virtual long Id { get; set; }
    
            public virtual ReadOnlyDictionary<string, ISet<PersistentClass>> MappedCollections 
            { 
                get 
                { 
                    return new ReadOnlyDictionary<string, ISet<PersistentClass>>(_mc); 
                } 
            }
            protected virtual IDictionary<string, PersistentClassSet> _mc { get; set; }
            public virtual void InitializeCollection(string key)
            {
                if (!_mk.ContainsKey(key))
                    _mc[key] = new PersistentClassSet();
            }
        }
    
        public class PersistentClass
        {
            public virtual long Id { get; protected set; }
            public virtual string Prop { get; set; }
        }
    
        internal class PersistentClassSet : ISet<PersisitentClass>
        {
            public PersistentClassSet()
            {
                Proxy = new HashSet<PersistentClass>();
            }
            protected virtual long Id { get; set; }
            protected virtual ISet<PersistentClass> Proxy { get; set; }
            
            public bool Add(PersistentClass item)
            {
                return Proxy.Add(item);
            }
    
            // other ISet implementations delegated to Proxy 
        }
    }
