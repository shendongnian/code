    public class AssignableProperty<T>
    {
        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                WasAssigned = true;
                _value = value;
            }
        }
        public bool WasAssigned { get; set; }
    }
