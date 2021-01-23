    public class EnumDictionarySerializer<TKey, TDictionary> : DictionarySerializerBase<TDictionary> 
        where TKey : struct
        where TDictionary : class, IDictionary, new()
    {
        public EnumDictionarySerializer():base(DictionaryRepresentation.Document, new EnumSerializer<TKey>(BsonType.String), new ObjectSerializer())
        {
        }
        protected override TDictionary CreateInstance()
        {
            return new TDictionary();
        }
    }
