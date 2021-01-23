    sealed class JsonSkipObjectException : JsonException
    {
    }
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        readonly Predicate<object> shouldSerialize;
        readonly SerializationCallback serializationCallback;
        readonly SerializationErrorCallback onErrorCallback;
        public ShouldSerializeContractResolver(Predicate<object> shouldSerialize)
            : base()
        {
            this.shouldSerialize = shouldSerialize;
            this.serializationCallback = (o, context) =>
                {
                    if (shouldSerialize != null && !this.shouldSerialize(o))
                        throw new JsonSkipObjectException();
                };
            this.onErrorCallback = (o, context, errorContext) =>
                {
                    if (errorContext.Error is JsonSkipObjectException)
                    {
                        errorContext.Handled = true;
                    }
                };
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (shouldSerialize != null)
            {
                if (property.Readable)
                {
                    var oldShouldSerialize = property.ShouldSerialize;
                    property.ShouldSerialize = (o) =>
                        {
                            var value = property.ValueProvider.GetValue(o);
                            if (oldShouldSerialize != null && !oldShouldSerialize(o))
                                return false;
                            if (!this.shouldSerialize(value))
                                return false;
                            return true;
                        };
                }
            }
            return property;
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            contract.OnSerializingCallbacks.Add(serializationCallback);
            contract.OnErrorCallbacks.Add(onErrorCallback);
            return contract;
        }
    }
