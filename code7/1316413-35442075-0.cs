        public static T GetProperty<T>(this object obj, string name)
        {
            Type type = obj.GetType(); // Get the object's type
            PropertyInfo pinfo = type.GetProperty(name); // Get the property information for the specified property name
            object ret = pinfo?.GetValue(obj); // If pinfo != null, get the value of the property on obj
            return ret == null ? default(T) : (T)ret; // If ret is null, return the default value for T (for example, "" if T is string). If it isn't, return ret casted to T
        }
