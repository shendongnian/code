    public class StringValueProvider : IValueProvider
    {
        private readonly string _value;
 
        public StringValueProvider(string value)
        {
            _value = value;
        }
 
        public void SetValue(object target, object value)
        {
            throw new NotSupportedException();
        }
 
        public object GetValue(object target)
        {
            return _value;
        }
    }
