    PropertyInfo Isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        
    Isreadonly.SetValue(Request.QueryString, false, null);
        
    Request.QueryString.Clear();
