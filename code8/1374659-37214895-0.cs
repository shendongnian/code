    public static int GetId(object obj)
        {
            Type type = obj.GetType();
            return Convert.ToInt32(type.GetProperty("ID").GetValue(obj, null));
        }
