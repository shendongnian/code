    DynamicMethod method =
        new DynamicMethod("Test", typeof(Dest), new Type[] { typeof(Source) });
    var generator = method.GetILGenerator();
    var constructor = typeof(Dest).GetConstructor(Type.EmptyTypes);
    var miGetter = typeof(Source).GetProperty("L1").GetMethod;
    var miDestGetter = typeof(Dest).GetProperty("L1").GetMethod;
    var addRange = typeof(List<int>).GetMethod("AddRange");
    var clear = typeof(List<int>).GetMethod("Clear");
    generator.Emit(OpCodes.Newobj, constructor);//Stack: DestObject
    generator.Emit(OpCodes.Dup);//Stack: DestObject,DestObject
    generator.Emit(OpCodes.Call, miDestGetter);//Stack: DestObject,DestObject.L1
    generator.Emit(OpCodes.Dup);//Stack: DestObject,DestObject.L1,DestObject.L1
    generator.Emit(OpCodes.Call, clear);//Stack: DestObject,DestObject.L1
    generator.Emit(OpCodes.Ldarg_0);//Stack: DestObject,DestObject.L1,SourceObject
    generator.Emit(OpCodes.Call, miGetter);//Stack: DestObject,DestObject.L1,SourceObject.L1
    
    generator.Emit(OpCodes.Call, addRange);//Stack: DestObject
    
    generator.Emit(OpCodes.Ret);
    var function = (Func<Source, Dest>)method.CreateDelegate(typeof(Func<Source, Dest>));
    Source source = new Source
    {
        L1 = new List<int>() { 1, 2, 3 }
    };
    var result = function(source);
