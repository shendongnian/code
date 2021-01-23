     public static T XmlToModel<T>(string xml)
        {
            StringReader xmlReader = new StringReader(xml);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            T t = (T)xmlSer.Deserialize(xmlReader);
            Type typeT = typeof(T);
            IfIsClass(t);
            return t;
        }
        private static void IfIsClass(object t)
        {
             var typeT = t.GetType();
            foreach (PropertyInfo p in typeT.GetProperties())
            {
                if (typeof(System.Collections.ICollection).IsAssignableFrom(p.PropertyType))
                {
                    var vValue = p.GetValue(t, null) as System.Collections.ICollection;
                    foreach(var item in vValue )
                    {
                        IfIsClass(item);
                    }
                }
                else
                {
                    IfIsNull(p, p.GetValue(t, null));
                }
            }
        }
        private static void IfIsNull(PropertyInfo p, object pvalue)
        {
            var at = p.GetCustomAttribute(typeof(NotNullAttribute));
            if (at != null && string.IsNullOrEmpty(pvalue == null ? "" : pvalue.ToString()))
            {
                throw new Exception(string.Format("field[{0}]not allow null or empty", p.Name));
            }
        }
