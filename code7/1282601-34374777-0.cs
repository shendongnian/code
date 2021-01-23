    public class ConfigParam<T>
    {
        string paramName;
        T paramValue;
        public ConfigParam(string name, T value)
        {
            paramName = name;
            paramValue = value;
        }
        public string ParamName
        {
            get { return paramName; }
            set { paramName = value; }
        }
        public T ParamValue
        {
            get { return paramValue; }
            set { paramValue = value; }
        }
    }
