    string GetPropertyAsString(object obj, string propertyName)
    {
      var propertyInfo - obj.GetType().GetProperty(propertyName);
      return propertyInfo.GetValue(obj).ToString();
    }
