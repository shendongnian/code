    public struct DocumentId<T> : IEquatable<DocumentId<T>>
    {
        static DocumentId()
        {
            BsonSerializer.RegisterSerializer(typeof(DocumentId<T>), DocumentIdSerializer<T>.Instance);
            BsonSerializer.RegisterIdGenerator(typeof(DocumentId<T>), DocumentIdGenerator<T>.Instance);
        }
        public static readonly DocumentId<T> Empty = new DocumentId<T>(ObjectId.Empty);
        public readonly ObjectId Value;
        public DocumentId(ObjectId value)
        {
            Value = value;
        }
        public static DocumentId<T> GenerateNewId()
        {
            return new DocumentId<T>(ObjectId.GenerateNewId());
        }
        public static DocumentId<T> Parse(string value)
        {
            return new DocumentId<T>(ObjectId.Parse(value));
        }
        public bool Equals(DocumentId<T> other)
        {
            return Value.Equals(other.Value);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DocumentId<T> && Equals((DocumentId<T>)obj);
        }
        public static bool operator ==(DocumentId<T> left, DocumentId<T> right)
        {
            return left.Value == right.Value;
        }
        public static bool operator !=(DocumentId<T> left, DocumentId<T> right)
        {
            return left.Value != right.Value;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    public class DocumentIdSerializer<T> : StructSerializerBase<DocumentId<T>>
    {
        public static readonly DocumentIdSerializer<T> Instance = new DocumentIdSerializer<T>();
        public override DocumentId<T> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return new DocumentId<T>(context.Reader.ReadObjectId());
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DocumentId<T> value)
        {
            context.Writer.WriteObjectId(value.Value);
        }
    }
    public class DocumentIdGenerator<T> : IIdGenerator
    {
        public static readonly DocumentIdGenerator<T> Instance = new DocumentIdGenerator<T>();
        public object GenerateId(object container, object document)
        {
            return DocumentId<T>.GenerateNewId();
        }
        public bool IsEmpty(object id)
        {
            var docId = id as DocumentId<T>? ?? DocumentId<T>.Empty;
            return docId.Equals(DocumentId<T>.Empty);
        }
    }
