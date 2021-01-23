        public static T PropertyOrDefault<T>(this ExpandoObject obj, string propertyName)
        {
            var dynamicAsDictionary = (IDictionary<string, object>)obj;
            if (!dynamicAsDictionary.ContainsKey(propertyName))
            {
                return default(T);
            }
            object propertyValue = dynamicAsDictionary[propertyName];
            if (!(propertyValue is T))
            {
                return default(T);
            }
            return (T)propertyValue;
        }
