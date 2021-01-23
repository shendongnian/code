    public class IParameter
        {
            public IParameter()
            {
                _value = new IValue();
            }
            public string Name { get; set; }
    
            public bool Required { get; set; }
    
            public dynamic Value
            {
                get { return _value.Value; }
                set
                {
                    _value.Value = value;
                }
            }
    
            private IValue _value { get; set; }
        }
