    public static class DaysAttributeCache
    {
        private static readonly string[] Cache;
    
        static DaysAttributeCache()
        {
            Type enumType = typeof(Days);
            Cache = new string[Enum.GetValues(enumType).Length];
            foreach (Enum value in Enum.GetValues(enumType))
            {
              var name = Days.GetName(enumType, value);
              DayAttribute attribute = enumType
                  .GetField(name)
                  .GetCustomAttributes(false)
                  .OfType<DayAttribute>()
                  .SingleOrDefault();
              string weekDay = attribute?.Name;
              Cache[((IConvertible)value).ToInt32(CultureInfo.InvariantCulture)] = weekDay;
            }
        }
    
        public static string GetWeekday(this Days value)
        {
            return Cache[(int)value];
        }
      }
    
