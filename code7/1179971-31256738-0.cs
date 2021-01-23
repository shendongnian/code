    class VolatileBoolWrapper
    {
        public bool Value { get { return _value; } }
        private volatile bool _value;
        public void SetValue(bool value)
        {
            _value = value;
        }
    }
