        public List<string> GetChangedProperties(object obj1, object obj2)
        {
            List<string> result = new List<string>();
            if(obj1 == null || obj2 == null )
                // just return empty result
                return result;
            if (obj1.GetType() != obj2.GetType())
                throw new InvalidOperationException("Two objects should be from the same type");
            Type objectType = obj1.GetType();
              // check if the objects are primitive types
            if (objectType.IsPrimitive || objectType == typeof(Decimal) || objectType == typeof(String) )
                {
                    // here we shouldn't get properties because its just   primitive :)
                    if (!object.Equals(obj1, obj2))
                        result.Add("Value");
                    return result;
                }
            var properties = objectType.GetProperties();
            foreach (var property in properties)
            {
                if (!object.Equals(property.GetValue(obj1), property.GetValue(obj2)))
                {
                    result.Add(property.Name);
                }
            }
            return result;
        }
