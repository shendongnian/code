    public static String Serialize(UrlEncodeSerializable obj)
    {
        // make sure all more complex data is prepared to manageable form first
        obj.PrepareAttributes();
        // go over the properties, see which ones have a UrlEncodeAttribute, and process them.
        StringBuilder sb = new StringBuilder();
        PropertyInfo[] properties = obj.GetType().GetProperties();
        foreach (PropertyInfo p in properties)
        {
            object[] attrs = p.GetCustomAttributes(true);
            object attr;
            foreach (Object tempLoopVar_attr in attrs)
            {
                attr = tempLoopVar_attr;
                if (attr is UrlEncodeAttribute)
                {
                    try
                    {
                        UrlEncodeAttribute fldAttr = ((UrlEncodeAttribute)attr);
                        String objectName = fldAttr.Name;
                        Object objectDataObj = p.GetValue(obj, null);
                        String objectData = objectDataObj == null ? "null" : objectDataObj.ToString();
                        objectData = HttpUtility.UrlEncode(objectData);
                        if (sb.Length > 0)
                            sb.Append("&");
                        sb.Append(objectName).Append("=").Append(objectData);
                    }
                    catch
                    {
                        // failed? I'unno.
                    }
                }
            }
        }
        return sb.ToString();
    }
