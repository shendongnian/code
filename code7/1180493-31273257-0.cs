        public Dictionary<string, object> ConvertClassToDict(object classToConvert)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            PropertyInfo[] properties = classToConvert.GetType().GetProperties();
            List<string> propertiesNames = properties.Select(p => p.Name).ToList();
            foreach (var propName in propertiesNames)
            {
                PropertyInfo property = properties.First(srcProp => srcProp.Name == propName);
                var value = property.GetValue(classToConvert, null);
                result.Add(propName, value);
            }
            return result;
        }
