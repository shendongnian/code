    class GuidQueryStringConverter : QueryStringConverter 
    {
        public override bool CanConvert(Type type)
        {
            return type == typeof(Guid) || base.CanConvert(type);
        }
        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            if (parameterType == typeof(Guid))
            {
                Guid guid;
                if(Guid.TryParse(parameter, out guid))
                {
                    return guid;
                }
            }
 
            return base.ConvertStringToValue(parameter, parameterType);
        }
    }
    public class GuidConverterWebHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new GuidQueryStringConverter();
        }
    }
