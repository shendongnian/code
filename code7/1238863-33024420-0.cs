    internal class GuidToStringConverter : QueryStringConverter 
    {
        public override bool CanConvert(Type type)
        {
            if(typeof(Guid) ==  type)
            {
                return true;
            }
            return false;
        }
        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            Guid obj;
            if(Guid.TryParse(parameter, out obj))
            {
                return obj;
            }
            throw new ArgumentException("Can not convert parameter value to Guid.");
        }
        public override string ConvertValueToString(object parameter, Type parameterType)
        {
            return base.ConvertValueToString(parameter, parameterType);
        }
    }
    public class MyWebHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new GuidToStringConverter();
        }
    }
