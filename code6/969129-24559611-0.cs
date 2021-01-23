    public class Parameter
    {
        public long Id {get; set;}
        public string Type {get; set;}
    }
    
    public class ParameterValues
    {
        public long Id {get; set;}
        public virtual Parameter Parameter {get; set;}
        public string Value {get;set;}
    }
    
    public class IntValue : ParameterValues
    {
        public int IntVal
        {
            get
            {
                return Int32.Parse(Value);
            }
        }
    }
