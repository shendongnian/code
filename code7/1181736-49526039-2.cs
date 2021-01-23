        public class ObjectConvertInfo
        {
            public object ConvertObject { set; get; }
            public IList<Type> IgnoreTypes { set; get; }
            public IList<string> IgnoreProperties { set; get; }
            public int MaxDeep { set; get; } = 3;
        }
        public Dictionary<string, string> ConvertObjectToDictionary(ObjectConvertInfo objectConvertInfo)
        {
            try
            {
                var dictionary = new Dictionary<string, string>();
                MapToDictionaryInternal(dictionary, objectConvertInfo, objectConvertInfo.ConvertObject.GetType().Name, 0);
                return dictionary;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private void MapToDictionaryInternal(IDictionary<string, string> dictionary, ObjectConvertInfo objectConvertInfo, string name, int deep)
        {
            try
            {
                if (deep > objectConvertInfo.MaxDeep)
                    return;
                var properties = objectConvertInfo.ConvertObject.GetType().GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (objectConvertInfo.IgnoreProperties.ContainIgnoreCase(propertyInfo.Name))
                        continue;
                    var key = name + "." + propertyInfo.Name;
                    var value = propertyInfo.GetValue(objectConvertInfo.ConvertObject, null);
                    if (value == null)
                        continue;
                    var valueType = value.GetType();
                    if (objectConvertInfo.IgnoreTypes.Contains(valueType))
                        continue;
                    if (valueType.IsPrimitive || valueType == typeof(String))
                    {
                        dictionary[key] = value.ToString();
                    }
                    else if (value is IEnumerable)
                    {
                        var i = 0;
                        foreach (var data in (IEnumerable)value)
                        {
                            MapToDictionaryInternal(dictionary, new ObjectConvertInfo
                            {
                                ConvertObject = data,
                                IgnoreTypes = objectConvertInfo.IgnoreTypes,
                                IgnoreProperties = objectConvertInfo.IgnoreProperties, MaxDeep = objectConvertInfo.MaxDeep
                            }, key + "[" + i + "]", deep + 1);
                            i++;
                        }
                    }
                    else
                    {
                        MapToDictionaryInternal(dictionary, new ObjectConvertInfo
                        {
                            ConvertObject = value,
                            IgnoreTypes = objectConvertInfo.IgnoreTypes,
                            IgnoreProperties = objectConvertInfo.IgnoreProperties, MaxDeep = objectConvertInfo.MaxDeep
                        }, key, deep + 1);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
