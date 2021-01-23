    public class KeyedIListMergeConverter : JsonConverter
    {
        readonly IContractResolver contractResolver;
        public KeyedIListMergeConverter(IContractResolver contractResolver)
        {
            if (contractResolver == null)
                throw new ArgumentNullException("contractResolver");
            this.contractResolver = contractResolver;
        }
        static bool CanConvert(IContractResolver contractResolver, Type objectType, out Type elementType, out JsonProperty keyProperty)
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
            Type elementType;
            JsonProperty keyProperty;
            if (!CanConvert(contractResolver, objectType, out elementType, out keyProperty))
                throw new JsonSerializationException(string.Format("Invalid input type {0}", objectType));
            if (reader.TokenType == JsonToken.Null)
                return existingValue;
            var method = GetType().GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
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
        object ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer, JsonProperty keyProperty)
        {
            var list = existingValue as IList<T>;
            if (list == null || list.Count == 0)
            {
                list = list ?? (IList<T>)contractResolver.ResolveContract(objectType).DefaultCreator();
                serializer.Populate(reader, list);
            }
            else
            {
                var jArray = JArray.Load(reader);
                var comparer = new KeyedListMergeComparer();
                var lookup = jArray.ToLookup(i => i[keyProperty.PropertyName].ToObject(keyProperty.PropertyType, serializer), comparer);
                var done = new HashSet<JToken>();
                foreach (var item in list)
                {
                    var key = keyProperty.ValueProvider.GetValue(item);
                    var replacement = lookup[key].Where(v => !done.Contains(v)).FirstOrDefault();
                    if (replacement != null)
                    {
                        using (var subReader = replacement.CreateReader())
                            serializer.Populate(subReader, item);
                        done.Add(replacement);
                    }
                }
                // Populate the NEW items into the list.
                if (done.Count < jArray.Count)
                    foreach (var item in jArray.Where(i => !done.Contains(i)))
                    {
                        list.Add(item.ToObject<T>(serializer));
                    }
            }
            return list;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        class KeyedListMergeComparer : IEqualityComparer<object>
        {
            #region IEqualityComparer<object> Members
            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                return object.Equals(x, y);
            }
            int IEqualityComparer<object>.GetHashCode(object obj)
            {
                if (obj == null)
                    return 0;
                return obj.GetHashCode();
            }
            #endregion
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type> GetIListItemTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
        }
    }
