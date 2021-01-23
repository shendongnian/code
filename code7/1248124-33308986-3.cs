    public class LocalizableSetting<T> : IEnumerable<KeyValuePair<string, T>>
    {
        private Dictionary<string, T> _values;
        
        public T this[string cultureName]
        {
            get { return _values[cultureName]; }
            set
            {
                _values[cultureName] = value;
            }
        }
        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }
        public static implicit operator T(LocalizableSetting<T> value)
        {
            return value[CultureInfo.CurrentCulture.Name];
        }
        
        public static implicit operator LocalizableSetting<T>(T value)
        {
            var setting = new LocalizableSetting<T>();
            setting[CultureInfo.CurrentCulture.Name] = value;
            return setting;
        }
    }
