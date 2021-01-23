    var typeA = objectA.GetType();
    var fEntityType = typeof(FEntity<>).MakeGenericType(typeA);
    var getMethod = fEntityType.GetMethod("Get").MakeGenericMethod(typeA);
    
    dynamic result = getMethod.Invoke(null, new[]{ Id });
    
    result.Delete();
