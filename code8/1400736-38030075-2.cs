    public interface Test
    {
        List<DoubleByRef> Numbers { get; set; }
        DoubleByRef Result { get; set; }
    }
    
    public class A : Test
    {
        public List<DoubleByRef> Numbers { get; set; } = new List<DoubleByRef>();
        public DoubleByRef Result { get; set; } = new DoubleByRef(0);
    }
    
    public class B : Test
    {
        public List<DoubleByRef> Numbers { get; set; } = new List<DoubleByRef>();
        public DoubleByRef Result { get; set; } = new DoubleByRef(0);
    }
    
    public class DoubleByRef
    {
        public double Value { set; get; }
        public DoubleByRef(double d)
        {
            Value = d;
        }
    
        public override string ToString()
        {
            return Value.ToString();
        }
    }
