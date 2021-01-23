    public interface ISerializableDictionary : IDictionary
    {
    }
    
    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable, ISerializableDictionary
