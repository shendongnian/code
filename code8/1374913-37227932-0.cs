    public static T Modify<T>(this T t,T tnew)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "id" && (property.PropertyType==typeof(string) || property.PropertyType==typeof(DateTime)))
                    property.SetValue(t, property.GetValue(tnew));
            }
            return t;
        }
