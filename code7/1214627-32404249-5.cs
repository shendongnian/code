    public class PolymorphicAssemblyRootConverter : JsonConverter
    {
        [ThreadStatic]
        static bool disabled;
        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }
        public override bool CanWrite { get { return !Disabled; } }
        public override bool CanRead { get { return !Disabled; } }
        readonly HashSet<Assembly> assemblies;
        public PolymorphicAssemblyRootConverter(IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null)
                throw new ArgumentNullException();
            this.assemblies = new HashSet<Assembly>(assemblies);
        }
        public override bool CanConvert(Type objectType)
        {
            return assemblies.Contains(objectType.Assembly);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val)) // Prevent infinite recursion of converters
            using (new PushValue<TypeNameHandling>(TypeNameHandling.Auto, () => serializer.TypeNameHandling, val => serializer.TypeNameHandling = val))
            {
                return serializer.Deserialize(reader, objectType);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val)) // Prevent infinite recursion of converters
            using (new PushValue<TypeNameHandling>(TypeNameHandling.Auto, () => serializer.TypeNameHandling, val => serializer.TypeNameHandling = val))
            {
                // Force the $type to be written unconditionally by passing typeof(object) as the type being serialized.
                serializer.Serialize(writer, value, typeof(object));
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
