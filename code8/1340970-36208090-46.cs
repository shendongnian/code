    public static String Serialize(Object obj, Boolean includeEmpty)
    {
        // go over the properties, see which ones have a UrlEncodeAttribute, and process them.
        StringBuilder sb = new StringBuilder();
        PropertyInfo[] properties = obj.GetType().GetProperties();
        foreach (PropertyInfo p in properties)
        {
            object[] attrs = p.GetCustomAttributes(true);
            foreach (Object attr in attrs)
            {
                if (attr is UrlEncodeAttribute)
                {
                    UrlEncodeAttribute fldAttr = ((UrlEncodeAttribute)attr);
                    String objectName = fldAttr.Name;
                    Object objectDataObj = p.GetValue(obj, null);
                    String objectData = objectDataObj == null ? String.Empty : objectDataObj.ToString();
                    if (!String.IsNullOrEmpty(objectData) || includeEmpty)
                    {
                        objectData = HttpUtility.UrlEncode(objectData);
                        objectName= HttpUtility.UrlEncode(objectName);
                        if (sb.Length > 0)
                            sb.Append("&");
                        sb.Append(objectName).Append("=").Append(objectData);
                    }
                    break; // Only handle one UrlEncodeAttribute per property.
                }
            }
        }
        return sb.ToString();
    }
