    public interface IProperty<out T> {
        T Value { get; set; }
    }
    
    public class Property<T> : IProperty<T> {
        public Property(T value) { this.Value = value; }
    
        T Value { get; set; }
    }
