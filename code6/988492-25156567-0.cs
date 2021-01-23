    var typeA = objectA.GetType();
    var getMethod = typeA.GetMethod("Get").MakeGenericMethod(typeA);
    
    dynamic result = getMethod.Invoke(objectA, new[]{ Id });
    
    result.Delete();
