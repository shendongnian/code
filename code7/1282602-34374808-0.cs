    public class ConfigParam
    {
        string paramName;
        object paramValue;
    
        public ConfigParam(string name, object value)
        {
            paramName = name;
            paramValue = value;
        }
    
        public string ParamName
        {
            get { return paramName; }
            set { paramName = value; }
        }
    
        public object ParamValue
        {
            get { return paramValue; }
            set { paramValue = value; }
        }
    }
