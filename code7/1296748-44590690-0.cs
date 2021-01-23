    public static class Extensions
    {
        public static T Unwrap<T>(this MongoObject<T> t)
        {
            return t.Element;
        }
    }
    public class MongoObject<T>
    {
        [BsonId]
        private ObjectId _objectId;
        public T Element { get; }
        public MongoObject(T element)
        {
            Element = element;
            _objectId = new ObjectId();
        }
    }
