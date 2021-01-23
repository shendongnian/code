    static private bool TryGetPropertyValue<T>(BindingList<T> bindingList, int classIndex, string propertyName, out object val)
        where T : class
        {
            try
            {
                Type type = typeof(T);
                PropertyInfo propertyInfo = type.GetProperty(propertyName);
                val = propertyInfo.GetValue(bindingList[classIndex], null);
                return val != null; // return true if val is not null and false if it is
            }
            catch (Exception ex)
            {
                // do something with the exception
                val = null;
                return false;
            }
        }
