    public interface IValue
    {
        int get_Value { get; }
    }
    public abstract class BaseClass : IValue
    {
        public abstract int get_Value { get; }
    }
    public class SubClass : BaseClass
    {
        public override int get_Value() { /* ... */ }
        
        // there's no set_Value to override in base class
        public override void set_Value(int value) { /* ... */ }
    }
