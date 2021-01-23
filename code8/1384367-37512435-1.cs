	public class StringLinesDeserializer<T> where T : new()
    {
        public T Deserialize(string[] assignments)
        {
            T result = new T();
            foreach (string assignment in assignments)
            {
                int commaPos = assignment.IndexOf(',');
                string propertyName = assignment.Substring(0, commaPos);
                string propertyValue = assignment.Substring(commaPos + 1);
                AssignProperty(result, propertyName, propertyValue);
            }
            return result;
        }
        private void AssignProperty(object obj, string propertyName, string propertyValue)
        {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            property.SetValue(obj, Convert.ChangeType(propertyValue, property.PropertyType), null);
        }
    }
