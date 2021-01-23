    public class MyModelConverter : JsonConverter
    {
        [ThreadStatic]
        static bool cannotWrite;
        // Disables the converter in a thread-safe manner.
        bool CannotWrite { get { return cannotWrite; } set { cannotWrite = value; } }
        public override bool CanWrite { get { return !CannotWrite; } }
        public override bool CanConvert(Type objectType)
        {
            return typeof(MyModel).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            obj.SelectToken("details.size").MoveTo(obj);
            obj.SelectToken("details.weight").MoveTo(obj);
            using (reader = obj.CreateReader())
            {
                // Using "populate" avoids infinite recursion.
                existingValue = (existingValue ?? new MyModel());
                serializer.Populate(reader, existingValue);
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Disabling writing prevents infinite recursion.
            using (new PushValue<bool>(true, () => CannotWrite, val => CannotWrite = val))
            {
                var obj = JObject.FromObject(value, serializer);
                var details = new JObject();
                obj.Add("details", details);
                obj["size"].MoveTo(details);
                obj["weight"].MoveTo(details);
                obj.WriteTo(writer);
            }
        }
    }
    public static class JsonExtensions
    {
        public static void MoveTo(this JToken token, JObject newParent)
        {
            if (newParent == null)
                throw new ArgumentNullException();
            if (token != null)
            {
                if (token is JProperty)
                {
                    token.Remove();
                    newParent.Add(token);
                }
                else if (token.Parent is JProperty)
                {
                    token.Parent.Remove();
                    newParent.Add(token.Parent);
                }
                else
                {
                    throw new InvalidOperationException();
                }
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
