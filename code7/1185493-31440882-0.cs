    public class HasCommonFieldsConverter<T> : JsonConverter where T : IHasCommonFields
    {
        [ThreadStatic]
        static bool disabled;
        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }
        public override bool CanWrite { get { return !Disabled; } }
        public override bool CanRead { get { return !Disabled; } }
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token == null || token.Type == JTokenType.Null)
                return null;
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val)) // Prevent infinite recursion of converters
            {
                var hasCommon = token.ToObject<T>(serializer);
                var common = (hasCommon.Common ?? (hasCommon.Common = new CommonFields()));
                serializer.Populate(token.CreateReader(), common);
                return hasCommon;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val))  // Prevent infinite recursion of converters
            {
                var hasCommon = (T)value;
                var obj = JObject.FromObject(hasCommon, serializer);
                var common = hasCommon.Common;
                if (common != null)
                {
                    var commonObj = JObject.FromObject(common, serializer);
                    obj.Merge(commonObj);
                }
                obj.WriteTo(writer);
            }
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        #region IDisposable Members
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
        #endregion
    }
