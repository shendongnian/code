    public class DTOTypeSurrogate : IDataContractSurrogate
    {
        // this determines how you want to replace one type with the other
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(DTO))
            {
                return typeof(DTO_UTC);
            }
            return type;
        }
    
        public object GetDeserializedObject(object obj, Type targetType)
        {
            // do we know this type
            if (targetType == typeof(DTO))
            {
                // find each DateTime prop and copy over
                var objType = obj.GetType();
                var target = Activator.CreateInstance(targetType);
                foreach(var prop in targetType.GetProperties())
                {
                    // value comes in
                    var src =  objType.GetProperty(prop.Name);
                    // do we need special handling
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        DateTime utcConvert;
                        // parse to a datetime
                        if (DateTime.TryParse(
                            (string) src.GetValue(obj),
                            System.Globalization.CultureInfo.InvariantCulture, 
                            System.Globalization.DateTimeStyles.AdjustToUniversal, 
                            out utcConvert))
                        {
                            // store 
                            prop.SetValue(target, utcConvert);
                        }
                    }
                    else
                    {
                        // store non DateTime types
                        prop.SetValue(target, src);
                    }
                }
                return target;
            }
            return obj;
        }
    
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            // go from DTO to DTO_UTC
            if (targetType == typeof(DTO_UTC))
            {
                var utcObj = Activator.CreateInstance(targetType);
                var objType = obj.GetType();
                // find our DateTime props
                foreach(var prop in objType.GetProperties())
                {
                    var src = prop.GetValue(obj);
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        // create the string
                        var dateUtc = (DateTime)src;
                        var utcString = dateUtc.ToString(
                            "yyyy-MM-ddThh:mm:ss.000Z", 
                            System.Globalization.CultureInfo.InvariantCulture);
                        // store
                        targetType.GetProperty(prop.Name).SetValue(utcObj, utcString);
                    } else
                    {
                        // normal copy
                        targetType.GetProperty(prop.Name).SetValue(utcObj, src);
                    }
                }
                return utcObj;
            }
            // unknown types return the original obj
            return obj;
        }
       // omitted the other methods in the interfaces for brevity
    }
