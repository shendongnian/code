    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class JsonMergeKeyAttribute : System.Attribute
    {
    }
    public abstract class KeyedListSynchronizingConverterBase : JsonConverter
    {
        protected static bool CanConvert(IContractResolver contractResolver, Type objectType, out Type elementType, out JsonProperty keyProperty)
        {
            if (objectType.IsArray)
            {
                // Not implemented for arrays, since they cannot be resized.
                elementType = null;
                keyProperty = null;
                return false;
            }
            var elementTypes = objectType.GetIListItemTypes().ToList();
            if (elementTypes.Count != 1)
            {
                elementType = null;
                keyProperty = null;
                return false;
            }
            elementType = elementTypes[0];
            var contract = contractResolver.ResolveContract(elementType) as JsonObjectContract;
            if (contract == null)
            {
                keyProperty = null;
                return false;
            }
            keyProperty = contract.Properties.Where(p => p.AttributeProvider.GetAttributes(typeof(JsonMergeKeyAttribute), true).Count > 0).SingleOrDefault();
            return keyProperty != null;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contractResolver = serializer.ContractResolver;
            Type elementType;
            JsonProperty keyProperty;
            if (!CanConvert(contractResolver, objectType, out elementType, out keyProperty))
                throw new JsonSerializationException(string.Format("Invalid input type {0}", objectType));
            if (elementType.IsValueType)
                throw new NotImplementedException("Not implemented for value types");
            if (reader.TokenType == JsonToken.Null)
                return null;
            var method = typeof(KeyedListSynchronizingConverterBase).GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(new[] { elementType });
            try
            {
                return genericMethod.Invoke(this, new object[] { reader, objectType, existingValue, serializer, keyProperty });
            }
            catch (TargetInvocationException ex)
            {
                // Wrap the TargetInvocationException in a JsonSerializationException
                throw new JsonSerializationException("ReadJsonGeneric<T> error", ex);
            }
        }
        object ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer, JsonProperty keyProperty) where T : class
        {
            var list = existingValue as IList<T>;
            if (list == null || list.Count == 0)
            {
                var contractResolver = serializer.ContractResolver;
                list = list ?? (IList<T>)contractResolver.ResolveContract(objectType).DefaultCreator();
                serializer.Populate(reader, list);
            }
            else
            {
                var jArray = JArray.Load(reader);
                var lookup = Enumerable.Range(0, list.Count)
                    .Where(i => list[i] != null)
                    .ToLookup(i => keyProperty.ValueProvider.GetValue(list[i]), i => KeyValuePair.Create(i, list[i]), EqualityComparer<object>.Default);
                var done = new HashSet<int>(); // In case there are duplicate keys, pair them in order.
                for (int i = 0, count = jArray.Count; i < count; i++)
                {
                    T item;
                    if (jArray[i].Type == JTokenType.Null)
                        item = null;
                    else
                    {
                        var key = jArray[i][keyProperty.PropertyName].ToObject(keyProperty.PropertyType, serializer);
                        var pair = lookup[key].Where(p => !done.Contains(p.Key)).FirstOrDefault();
                        item = pair.Value;
                        if (item == null)
                        {
                            item = jArray[i].ToObject<T>(serializer);
                        }
                        else
                        {
                            using (var subReader = jArray[i].CreateReader())
                                serializer.Populate(subReader, item);
                        }
                        done.Add(pair.Key);
                    }
                    if (i < list.Count)
                        list[i] = item;
                    else
                        list.Add(item);
                }
                while (list.Count > jArray.Count)
                    list.RemoveAt(list.Count - 1);
            }
            return list;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class KeyedListSynchronizingConverter : KeyedListSynchronizingConverterBase
    {
        readonly IContractResolver contractResolver;
        public KeyedListSynchronizingConverter(IContractResolver contractResolver)
        {
            if (contractResolver == null)
                throw new ArgumentNullException("contractResolver");
            this.contractResolver = contractResolver;
        }
        public override bool CanConvert(Type objectType)
        {
            Type elementType;
            JsonProperty keyProperty;
            return CanConvert(contractResolver, objectType, out elementType, out keyProperty);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (contractResolver != serializer.ContractResolver)
                throw new InvalidOperationException("Inconsistent contract resolvers");
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
    public class KeyedListPropertySynchronizingConverter : KeyedListSynchronizingConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException("This converter is intended to be applied to a specific property, rather than globally");
        }
    }
