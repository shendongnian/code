    public static void SendEmail(Company cm)
    {
      string _body = "";
      string _subject = "ASN Form Request";
    
      _body = ReflectObject(cm, _body)
    }
    
    public static void ReflectObject(object obj, string body)
    {
      var type = obj.GetType();
      var properties = type.GetProperties();
      
      foreach(PropertyInfo property in properties)
      {
        if (property.PropertyType == typeof(string) || property.PropertyType == typeof(int) || property.PropertyType == typeof(bool))
          body += property.Name + " = " + property.GetValue(cm, null) + Environment.NewLine;
    
        if (property.PropertyType == typeof(List<>))
        {
          var list = property.GetValue(obj, null)
          
          foreach(var item in list)
          {
            ReflectObject(item, body);
          }
        }
      }
    
      return body;
    }
