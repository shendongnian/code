    public static T Modify<T>(this T t,T tnew)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "id" && (property.PropertyType==typeof(string) || property.PropertyType==typeof(DateTime)))
                {
                    if (property.GetValue(tnew) != null)
                    property.SetValue(t, property.GetValue(tnew));
                }
            }
            return t;
        }
