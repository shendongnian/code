    public abstract class Base<T> where T : Base<T>, new()
    {
        public static T Create()
        {
            var instance = new T();
            instance.Configure(42);
            return instance;
        }
        protected abstract void Configure(int value);
    }
    public class Actual : Base<Actual>
    {
        protected override void Configure(int value) { ... }
    }
    ...
     Actual a = Actual.Create(); // Create is defined in Base, but returns Actual
