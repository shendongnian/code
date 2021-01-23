    public class Parameter
    {
        public long Id {get; set;}
        public string Type {get; set;}
    }
    
    public class ParameterValues
    {
        public long Id {get; set;}
        public Parameter Parameter {get; set;}
        public string Value {get;set;}
    
        public ParameterValues(long id, Parameter param, string val)
        {
            Id = id;
            Parameter = param;
            Value = val;
        }
    }
    
    public class IntValue : ParameterValues
    {
        public IntValue(ParameterValues value)
            : base(value.Id, value.Parameter, value.Value)
        {
        }
    
        public int GetValue()
        {
            return Int32.Parse(Value);
        }
    }
