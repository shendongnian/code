       public class LineItemFieldNameResolver : IAssociateFieldNameResolver
            {
                public string ResolveFieldName(object i_Object)
                {
                    var item = (i_Object as LineItem);
                    return "lineitem";
                }
            }
     
            public class AssociativeArraysConverter<T> : JsonConverter
                where T : IAssociateFieldNameResolver, new()
            {
                private readonly T _mFieldNameResolver;
    
                public AssociativeArraysConverter()
                {
                    _mFieldNameResolver = new T();
                }
    
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                    JsonSerializer serializer)
                {
                    throw new NotImplementedException(
                        "Unnecessary because CanRead is false. The type will skip the converter.");
                }
    
                public override bool CanRead
                {
                    get { return false; }
                }
    
                public override bool CanConvert(Type objectType)
                {
                    return typeof(IEnumerable).IsAssignableFrom(objectType) &&
                           !typeof(string).IsAssignableFrom(objectType);
                }
    
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var collectionObj = value as IEnumerable;
    
                    writer.WriteStartObject();
    
                    foreach (var currObj in collectionObj)
                    {
                        writer.WritePropertyName(_mFieldNameResolver.ResolveFieldName(currObj));
                        serializer.Serialize(writer, currObj);
                    }
    
                    writer.WriteEndObject();
                }
            }
    
            public interface IAssociateFieldNameResolver
            {
                string ResolveFieldName(object i_Object);
            }
