    class Element<T> {
        public T Object { get; set; }
        public void SwapWith(Element<T> other) {
            // warning: this is not thread-safe
            T tmp = other.Object;
            other.Object = this.Object;
            this.Object = tmp;
        }
    }
