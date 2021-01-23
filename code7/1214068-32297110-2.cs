    class ParameterHandler
    {
        public static Dictionary<string, Converter> parameters = new Dictionary<string, Converter>();
        public static void addParameter<T>(string parameterName, Converter<T> converter){
            parameters.Add(parameterName, converter);
        }
        static T getValue<T>(string parameterName, string stringValue){
            if(!parameters[parameterName] is Convereter<T>)
                 throw new Exception("Invalid Type");
            return ((Convereter<T>)parameters[parameterName]).getValue(stringValue);
        }
    }
