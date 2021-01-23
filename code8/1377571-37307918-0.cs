    //Assuming "typeName" is a string defining the generic parameter for the
    //type you want to create.
    var genericTypeArgument = Type.GetType(typeName);
    var genericType = typeof (MyGenericType<>).MakeGenericType(genericTypeArgument);
    var instance = Activator.CreateInstance(genericType);
