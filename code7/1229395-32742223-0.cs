    namespace YourProject.Extensions
    {
        public static class ModelExtensions
        {
            public static IEnumerable<KeyValuePair<string, object>> ModifiedValues<T>(this T obj, T modifiedObject) 
            {
                foreach (var property in typeof(T).GetProperties().Where(p => !p.GetGetMethod().IsVirtual))
                {
                    if (property.GetValue(obj).ToString() != property.GetValue(modifiedObject).ToString())
                    {
                        yield return new KeyValuePair<string, object>(property.Name, property.GetValue(modifiedObject));
                    }
                }
            }
        }
    }
