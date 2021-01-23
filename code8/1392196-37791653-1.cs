    var type = Assembly.Load("ProjectA.B.C").GetTypes().First(x => x.Name.Equals("Caching", StringComparison.Ordinal));
    var methods = type.GetMethods();
    var getOrSetMethod = methods.First(x => x.Name.Equals("GetOrSet", StringComparison.Ordinal) && x.ReturnType.Name.Equals("Boolean", StringComparison.Ordinal)).MakeGenericMethod(typeof(bool));
    var getMethod = methods.First(x => x.Name.Equals("Get", StringComparison.Ordinal)).MakeGenericMethod(typeof(bool));
    var resultToSet = true;
    Func<bool> action = () => { return resultToSet; };
    if (!(bool)getOrSetMethod.Invoke(null, new object[] { "GetOrSet", action, resultToSet, (TimeSpan?)null }))
    	throw new Exception("Could not set the GetOrSet key to a boolean value of true.");
    var parameters = new object[] { "GetOrSet", resultToSet };
    if (!(bool)getMethod.Invoke(null, parameters))
    	throw new Exception("Could not get back the GetOrSet key.");
    if ((bool)parameters[1] != true)
    	throw new Exception("Got the wrong GetOrSet key back.");
