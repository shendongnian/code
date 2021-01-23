        public class ParameterFlag
        {
            public ParameterFlag(ParameterType parameterType, bool flag)
            {           
                ParameterType = parameterType;
                Flag = flag;
            }
            
            public ParameterType ParameterType
            {
                get;
                set;
            }
        
            public bool Flag
            {
                get;
                set;
            }
        }
    
