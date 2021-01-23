    public interface IValue
    {
        int Value { get; set; }
    }
    
    public abstract class BaseClass
    {
        int value;
        int Value { get { return value; } }
    }
    
    public class SubClass : BaseClass, IValue
    {
        public int Value { get { return Value; } set { this.Value = value; } }
    }
