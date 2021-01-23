    public class DowncastingConverter<TBase, TDerived> : PolymorphicCreationConverter<TBase> where TDerived : TBase
    {
        protected override TBase Create(Type objectType, Type polymorphicType, object existingValue, IContractResolver contractResolver, JObject obj)
        {
            Type createType = objectType;
            if (createType.IsAssignableFrom(polymorphicType))
                createType = polymorphicType;
            if (createType.IsAssignableFrom(typeof(TDerived)))
                createType = typeof(TDerived);
            if (existingValue != null && createType.IsAssignableFrom(existingValue.GetType()))
                return (TBase)existingValue;
            var contract = contractResolver.ResolveContract(createType);
            return (TBase)contract.DefaultCreator();
        }
    }
    public abstract class PolymorphicCreationConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader);
            Type polymorphicType = null;
            var polymorphicTypeString = (string)obj["$type"];
            if (polymorphicTypeString != null)
            {
                if (serializer.TypeNameHandling != TypeNameHandling.None)
                {
                    string typeName, assemblyName;
                    ReflectionUtils.SplitFullyQualifiedTypeName(polymorphicTypeString, out typeName, out assemblyName);
                    polymorphicType = serializer.Binder.BindToType(assemblyName, typeName);
                }
                obj.Remove("$type");
            }
            var value = Create(objectType, polymorphicType, existingValue, serializer.ContractResolver, obj);
            if (value == null)
                throw new JsonSerializationException("No object created.");
            using (var subReader = obj.CreateReader())
                serializer.Populate(subReader, value);
            return value;
        }
        protected abstract T Create(Type objectType, Type polymorphicType, object existingValue, IContractResolver iContractResolver, JObject obj);
        public override bool CanWrite { get { return false; } }
    }
    internal static class ReflectionUtils
    {
        // Utilities taken from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/ReflectionUtils.cs
        // I couldn't find a way to access these directly.
        public static void SplitFullyQualifiedTypeName(string fullyQualifiedTypeName, out string typeName, out string assemblyName)
        {
            int? assemblyDelimiterIndex = GetAssemblyDelimiterIndex(fullyQualifiedTypeName);
            if (assemblyDelimiterIndex != null)
            {
                typeName = fullyQualifiedTypeName.Substring(0, assemblyDelimiterIndex.GetValueOrDefault()).Trim();
                assemblyName = fullyQualifiedTypeName.Substring(assemblyDelimiterIndex.GetValueOrDefault() + 1, fullyQualifiedTypeName.Length - assemblyDelimiterIndex.GetValueOrDefault() - 1).Trim();
            }
            else
            {
                typeName = fullyQualifiedTypeName;
                assemblyName = null;
            }
        }
        private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
        {
            int scope = 0;
            for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
            {
                char current = fullyQualifiedTypeName[i];
                switch (current)
                {
                    case '[':
                        scope++;
                        break;
                    case ']':
                        scope--;
                        break;
                    case ',':
                        if (scope == 0)
                        {
                            return i;
                        }
                        break;
                }
            }
            return null;
        }
    }
