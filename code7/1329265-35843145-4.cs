    public interface IEntityWithUniqueId
    {
        void SetUniqueId(string uniqueId);
        string UniqueId { get; }
    }
    public interface IUniqueIdsProvider
    {
        string GetNewId();
    }
    public class UniqueObject : IEntityWithUniqueId
    {
        public string UniqueId { get; private set; }
        void IEntityWithUniqueId.SetUniqueId(string uniqueId)
        {
            UniqueId = uniqueId;
        }
    }
    public class MyObjects : UniqueObject
    {
        
    }
    public class RemoteUniqueIdsProvider : IUniqueIdsProvider
    {
        public string GetNewId()
        {
            // calling a service ...., grab an unique ID
            return Guid.NewGuid().ToString().Replace ("-", "");
        }
    }
    public class UniqueObjectsFactory<T> where T : IEntityWithUniqueId, new ()
    {
        private IUniqueIdsProvider _uniqueIdsProvider;
        public UniqueObjectsFactory(IUniqueIdsProvider uniqueIdsProvider)
        {
            _uniqueIdsProvider = uniqueIdsProvider;
        }
        public T GetNewEntity()
        {
            var x = new T();
            x.SetUniqueId(_uniqueIdsProvider.GetNewId ());
            return x;
        }
    }
