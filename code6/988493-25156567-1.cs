    var typeA = objectA.GetType();
    var getMethod = typeA.GetMethod("Get").MakeGenericMethod(typeA);
    
    dynamic result = getMethod.Invoke(null, new[]{ Id });
    
    result.Delete();
