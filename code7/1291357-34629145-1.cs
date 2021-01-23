    string jobDesc = getDtlName(serviceResponse.ErrorMessages[0].Error);
    SomeClass myClass = new SomeClass();
    // set some class values,
    var classType = typeof(SomeClass );                   
    PropertyInfo info = classType.GetProperty(jobDesc);
    var propertyValue = info.GetValue(myClass, null);
