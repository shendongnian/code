     var properties = parameter.ParameterDescriptor.ParameterType.GetProperties();
     var _prop = properties[2];
     Type _objType = _prop.PropertyType;
     object objInstance = Activator.CreateInstance(_objType);
    foreach (var subProperty in objInstance.GetType().GetProperties())
      {
          APIEndPointParameter _APIEndPointSubParameter = new APIEndPointParameter(subProperty.Name, "", "", false, subProperty.PropertyType.ToString(), null);
          _APIEndPointParameter.SubParameters.Add(_APIEndPointSubParameter);
       }
