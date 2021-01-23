    if (classType.Name == "ClassIO")
    {
        //You can get the property like this (if eIoType is public)
        var propertyInfo = classType.GetProperty("eIoType");
        if (propertyInfo != null)
        {
            //...
        }
    
        //You can get the method like this
        var methodInfo = classType.GetMethod("Action");
        if (methodInfo != null)
        {
            //create an instance of ClassIO
            var classInstance = Activator.CreateInstance(classType, new eGuiType(), ClassIO.eIoType.MONITOR);
            //Execute Action method
            methodInfo.Invoke(classInstance, null);
        }
    }
