    static void ExtractData(Log log)
    {
        List<PropertyInfo> propertyInfos =
            log.GetType()
                .GetProperties()
                .Where(
                    p => p.GetCustomAttributes(typeof (LogItem), true).Any(logItem => !((LogItem) logItem).Ignore))
                .ToList();
    
        foreach (var propertyInfo in propertyInfos)
        {
            LogItem logItem = (LogItem)propertyInfo.GetCustomAttributes(typeof(LogItem), true).First();
    
            if(!log.Dictionary.ContainsKey(logItem.Key))
                continue;
    
            TypeConverter typeConverter = TypeDescriptor.GetConverter(propertyInfo.PropertyType);
            MethodInfo parseNumberMethod = propertyInfo.PropertyType.GetMethod("Parse",
                new[] { typeof(String), typeof(NumberStyles), typeof(IFormatProvider) });
            MethodInfo parseExactMethod = propertyInfo.PropertyType.GetMethod("ParseExact",
                new[] { typeof(string), typeof(string), typeof(IFormatProvider) });
    
            Object objValue = null;
    
            if (typeConverter.CanConvertFrom(typeof(string)))
            {
                objValue = typeConverter.ConvertFromString(null, CultureInfo.CurrentCulture, log.Dictionary[logItem.Key]);
                Debug.WriteLine("TypeConverter - " + propertyInfo.Name);
            }
            else if (parseExactMethod != null)
            {
                objValue =
                    parseExactMethod.Invoke(
                        propertyInfo.PropertyType,
                        new Object[]
                            {
                                log.Dictionary[logItem.Key],
                                logItem.OutputFormat,
                                CultureInfo.CurrentCulture
                            });
            }
            else if (parseNumberMethod != null)
            {
                objValue =
                    parseNumberMethod.Invoke(
                        propertyInfo.PropertyType,
                        new Object[]
                            {
                                log.Dictionary[logItem.Key],
                                logItem.NumberStyles,
                                CultureInfo.CurrentCulture
                            });
            }
            else
            {
                objValue = log.Dictionary[logItem.Key];
            }
    
    		PropertyInfo goodPropertyInfo = propertyInfo.DeclaringType.GetProperty(propertyInfo.Name);
            goodPropertyInfo.SetValue(log, objValue, null);
        }
    }
