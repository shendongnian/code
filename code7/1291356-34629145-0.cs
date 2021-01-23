    string jobDesc = getDtlName(serviceResponse.ErrorMessages[0].Error);
    Class myClass = Class.forName(jobDesc);
    var classType = typeof(Class);                   
    PropertyInfo info = classType.GetProperty(jobDesc);
    var propertyValue = info.GetValue(myClass, null);
