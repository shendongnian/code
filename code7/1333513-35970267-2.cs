    [SerializableAttribute]
    [ComVisibleAttribute(false)]
    [HostProtectionAttribute(SecurityAction.LinkDemand, Synchronization = true, 
    	ExternalThreading = true)]
    public class ConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>, 
    	ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, 
    	IDictionary, ICollection, IEnumerable
