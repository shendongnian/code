    public interface IVariableValue { }
    public class VariableValue<T> : IVariableValue
    {
        public T Value { get; set; }
    
        public VariableValue(T value) { Value = value; }
        public override ToString() { return Value.ToString(); }
    }
