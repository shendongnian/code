    public static T ConvertOracleValue<T>(this object value)
    {
         if (value != null)
         {
              Type typeOfValue = value.GetType();
    
              if (typeOfValue.Namespace.Contains("Oracle.DataAccess"))
              {
                  if (typeOfValue.Name.Equals("OracleTimeStamp"))
                  {
                       int tempInt = 0;
                       Oracle.DataAccess.Types.OracleTimeStamp ots = (Oracle.DataAccess.Types.OracleTimeStamp)value;
                       tempInt = Int32.TryParse(ots.Millisecond.ToString("000").Substring(0, 3), out tempInt) ? tempInt : 0;
                       DateTime ret = new DateTime(ots.Year, ots.Month, ots.Day, ots.Hour, ots.Minute, ots.Second, tempInt);
                        return ConvertHelper.ConvertValue<T>(ret);
                  }
                  if (typeOfValue.Name.Equals("OracleTimeStampLTZ"))
                  {
                        int tempInt = 0;
                        Oracle.DataAccess.Types.OracleTimeStampLTZ ots = (Oracle.DataAccess.Types.OracleTimeStampLTZ)value;
                        tempInt = Int32.TryParse(ots.Millisecond.ToString("000").Substring(0, 3), out tempInt) ? tempInt : 0;
                        DateTime ret = new DateTime(ots.Year, ots.Month, ots.Day, ots.Hour, ots.Minute, ots.Second, tempInt);
                        return ConvertHelper.ConvertValue<T>(ret);
                  }
                  if (typeOfValue.Name.Equals("OracleTimeStampTZ"))
                  {
                        int tempInt = 0;
                        Oracle.DataAccess.Types.OracleTimeStampTZ ots = (Oracle.DataAccess.Types.OracleTimeStampTZ)value;
                        tempInt = Int32.TryParse(ots.Millisecond.ToString("000").Substring(0, 3), out tempInt) ? tempInt : 0;
                        DateTime ret = new DateTime(ots.Year, ots.Month, ots.Day, ots.Hour, ots.Minute, ots.Second, tempInt);
                        return ConvertHelper.ConvertValue<T>(ret);
                  }
    
                  string temp = value.ToString();
                  return ConvertHelper.ConvertValue<T>(temp);
              }
          }
          else
          {
               return default(T);
          }
    
          return ConvertHelper.ConvertValue<T>(value);
    }
