    public class Parameter {
        public System.Type type { get; private set; }
        protected Parameter(System.Type type) {
            this.type = type;
        }
        public bool IsA<T>() {
            return type.Equals(typeof(T));
        }
        public T Get<T>() {
            return ((ParameterType<T>)this).val;
        }
        static public Parameter Create<T>(T defaultVal) {
            return new ParameterType<T>(defaultVal);
        }
    }
    class ParameterType<T> : Parameter {
        public T val { get; set; }
        public ParameterType() : base(typeof(T)) {
        }
        public ParameterType(T value) : base(typeof(T)) {
            this.val = value;
        }
    }
