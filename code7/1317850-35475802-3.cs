      var propertyInfo = someObject.GetType().GetProperty("property name");
        if (propertyInfo == null)
            throw new Exception(string.Format("Property does not exist:{0}", condition.Property));
        
        var propertyValue = propertyInfo.GetValue(someObject, null);
        long longValue = (long)propertyValue;
        
        //You can get methods in a smilar manner and execute with
        result = methodInfo.Invoke(methodInfo, parametersArray);
