    public class BaseDataObject
        {
            internal T FindPropertyType<T>(string strMember)
            {
                var type = this.GetType();
                var props = type.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    if (prop.PropertyType.Name.ToString().ToLower() == strMember.ToLower())
                        //This is where it goes wrong!
                        return (T)prop.GetValue(this, null);
                }
                return default(T);
            }
    
        }
