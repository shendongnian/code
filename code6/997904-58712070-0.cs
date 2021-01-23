    Dictionary<string, object> dictionaryObject = new Dictionary<string, object>();
            if (anonymousObject is string)
            {
                dictionaryObject = JsonConvert.DeserializeObject<Dictionary<string,object>>((string)anonymousObject);
            }
            if (!dictionaryObject.ContainsKey(propertyName))
            {
                throw new Exception($"property name '{propertyName}' not found");
            }
            object value = dictionaryObject[propertyName];
