    if (classType.Name == "ClassIO")
    {
        //You can get the field like this
        var fieldInfo = classType.GetField("ioType",BindingFlags.NonPublic|BindingFlags.Instance);
        if (fieldInfo != null)
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
