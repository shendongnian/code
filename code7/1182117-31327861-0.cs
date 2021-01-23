        static object GetAttributeValue<T, A>(string attribName, string propName = "") where A : Attribute
        {
            object[] attribs = null;
            if (string.IsNullOrEmpty(propName))
                attribs = typeof(T).GetCustomAttributes(true);
            else
            {
                PropertyInfo pi = typeof(T).GetProperty(propName);
                if (pi == null)
                    return null;
                attribs = pi.GetCustomAttributes(true);
            }
            A a = null;
            foreach (object attrib in attribs)
            {
                if (attrib is A)
                {
                    a = attrib as A;
                    break;
                }
            }
            if (a != null)
            {
                var prop = a.GetType().GetProperty(attribName);
                return prop.GetValue(a, null);
            }
            return null;
        }
