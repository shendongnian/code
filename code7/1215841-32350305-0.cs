    // http://stackoverflow.com/questions/11162652/c-sharp-get-property-value-without-creating-instance/11162876#11162876
    var method = type.GetProperty("ProjectionTypeName").GetGetMethod();
    var dynamicMethod = new DynamicMethod("TempUglyPropertyGetMethod", typeof(string),
        Type.EmptyTypes, Assembly.GetExecutingAssembly().ManifestModule);
    var generator = dynamicMethod.GetILGenerator();
    generator.Emit(OpCodes.Ldnull);
    generator.Emit(OpCodes.Call, method);
    generator.Emit(OpCodes.Ret);
    var tempUglyPropertyGetMethod = (Func<string>)dynamicMethod.CreateDelegate(typeof(Func<string>));
    var projectionTypeName = tempUglyPropertyGetMethod();
