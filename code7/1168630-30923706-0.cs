    public interface IValue {
        public int Value { get; }
    }
    public abstract class BaseClass : IValue {
        public abstract int Value { get; }
    }
    public class SubClass : BaseClass {
        protected int val;
        public int Value { get { return val; } }
        public int SetValue (int value) { val = value; }
    }
    public class SubClassWithoutSetter : BaseClass {
        public int Value { get { return 50; } }
    }
