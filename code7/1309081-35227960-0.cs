    public abstract class Entity<T> {
        protected Entity(T id) {
            Id = id;
        }
        public T Id { get; private set; }
    }
