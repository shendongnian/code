    public sealed class Maybe<T> {
        private readonly T value;
        private readonly bool hasValue;
    
        private Maybe() {
            hasValue = false;
        }
    
        public readonly Maybe<T> Nothing = new Maybe();
    
        public Maybe(T value) {
            this.value = value;
            hasValue = true;
        }
    
        public T Value {
            get {
                return value;
            }
        }
    
        public bool HasValue {
            get {
                return value;
            }
        }
    }
