    public interface IProperty<out T> {
        T GetValue();
    }
    public class Property<T> : IProperty<T> {
        private T value;
        public Property(T value) { this.value = value; }
        public T GetValue() { return this.value; }
    }
