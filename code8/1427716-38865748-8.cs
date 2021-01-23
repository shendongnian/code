    public static List<T> BindList<T>(DataTable dt)
    {
        // Example 1:
        // Get private fields + non properties
        //var fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
    
        // Example 2: Your case
        // Get all public fields
        var fields = typeof(T).GetFields();
    
        List<T> lst = new List<T>();
    
        foreach (DataRow dr in dt.Rows)
        {
            // Create the object of T
            var ob = Activator.CreateInstance<T>();
    
            foreach (var fieldInfo in fields)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    // Matching the columns with fields
                    if (fieldInfo.Name == dc.ColumnName)
                    {
                        Type type = fieldInfo.FieldType;
                        // Get the value from the datatable cell
                        object value = GetValue(dr[dc.ColumnName], type);
    
                        // Set the value into the object
                        fieldInfo.SetValue(ob, value);
                        break;
                    }
                }
            }
    
            lst.Add(ob);
        }
    
        return lst;
    }
    static object GetValue(object ob, Type targetType)
    {
        if (targetType == null)
        {
            return null;
        }
        else if (targetType == typeof(String))
        {
            return ob + "";
        }
        else if (targetType == typeof(int))
        {
            int i = 0;
            int.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(short))
        {
            short i = 0;
            short.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(long))
        {
            long i = 0;
            long.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(ushort))
        {
            ushort i = 0;
            ushort.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(uint))
        {
            uint i = 0;
            uint.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(ulong))
        {
            ulong i = 0;
            ulong.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(double))
        {
            double i = 0;
            double.TryParse(ob + "", out i);
            return i;
        }
        else if (targetType == typeof(DateTime))
        {
            // do the parsing here...
        }
        else if (targetType == typeof(bool))
        {
            // do the parsing here...
        }
        else if (targetType == typeof(decimal))
        {
            // do the parsing here...
        }
        else if (targetType == typeof(float))
        {
            // do the parsing here...
        }
        else if (targetType == typeof(byte))
        {
            // do the parsing here...
        }
        else if (targetType == typeof(sbyte))
        {
            // do the parsing here...
        }
        else if........
        ..................
    
        return ob;
    }
