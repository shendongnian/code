        static private bool ProcessBookTitle<T>(BindingList<T> bindingList, int classIndex, string propertyName) 
            where T : class
        {
            try
            {
                Type type = typeof(T);
                PropertyInfo propertyInfo = type.GetProperty(propertyName);
                object val = "Do some processing whatever here.";
                propertyInfo.SetValue(bindingList[classIndex], Convert.ChangeType(val, propertyInfo.PropertyType), null);
                return true;
            }
            catch (Exception ex)
            {
                // do something with the exception
                return false;
            }
        }
