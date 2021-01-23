    public class CalendarExceptionEnumConverter<T> : DefaultTypeConverter  where T : struct
        {
            public override string ConvertToString(TypeConverterOptions options, object value)
            {
                T result;
                if(Enum.TryParse<T>(value.ToString(),out result))
                {
                    return (Convert.ToInt32(result)).ToString();
                }
                
                throw new InvalidCastException(String.Format("Invalid value to EnumConverter. Type: {0} Value: {1}",typeof(T),value));
            }
        }
