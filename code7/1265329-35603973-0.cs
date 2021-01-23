    class DefaultUrlParameterFormatter : IUrlParameterFormatter
    {
        public string Format(object value, ParameterInfo parameterInfo)
        {
            if (value == null)
                return null;
            if (parameterInfo.ParameterType.IsPrimitive)
                return value.ToString();
            var convertible = value as IConvertible; //e.g. string, DateTime
            if (convertible != null)
                return convertible.ToString();
            
            return JsonConvert.SerializeObject(value);
        }
    }
    var settings = new RefitSettings
    {
        UrlParameterFormatter = new DefaultUrlParameterFormatter()
    };
