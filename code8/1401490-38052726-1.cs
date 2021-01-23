    public class EntitySetMgrFactory
    {
    
        public delegate IEntitySetMgr<T> EntitySetMgrCreator<T>();
    
        private readonly Dictionary<string, object> _creators = new Dictionary<string, object>();
    
        private static EntitySetMgrFactory _instance;
        public static EntitySetMgrFactory Instance => _instance ?? (_instance = new EntitySetMgrFactory());
    
        private EntitySetMgrFactory() { }
    
        public bool registerEntitySetMgr<T>(string setName, EntitySetMgrCreator<T> creator)
        {
            if (_creators.ContainsKey(setName)) return false;
            _creators[setName] = creator;
            return true;
        }
    
        public IEntitySetMgr<T> getEntitySetMgr<T>(string setName) => _creators.ContainsKey(setName) ? ((EntitySetMgrCreator<T>)_creators[setName])() : null;
    }
