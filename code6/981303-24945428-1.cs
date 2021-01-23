    public interface INamedObject { string Name { get; } }
    public interface IValuedObject<T> { T Value { get; } }
    public interface INamedValuedObject<T> {
       string Name { get; }
       T Value { get; }
    }
