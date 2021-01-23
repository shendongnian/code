    public class CountryHandler : SqlMapper.ITypeHandler
    {
        public object Parse(Type destinationType, object value)
        {
            if (destinationType == typeof(Country))
                return (Country)((string)value);
            else return null;
        }
        public void SetValue(IDbDataParameter parameter, object value)
        {
            parameter.DbType = DbType.String;
            parameter.Value = (string)((dynamic)value);
        }
    }
