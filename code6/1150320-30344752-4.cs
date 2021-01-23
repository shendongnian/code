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
        public bool WasAssigned { get;protected set; }
        public static implicit operator AssignableProperty<T>(T data)
        {
            return new AssignableProperty<T>(){Value = data};
        }
        public static bool operator ==(AssignableProperty<T> initial, T data)
        {
            return initial.Value.Equals(data);
        }
        public static bool operator !=(AssignableProperty<T> initial, T data)
        {
            return !initial.Value.Equals(data);
        }
    }
