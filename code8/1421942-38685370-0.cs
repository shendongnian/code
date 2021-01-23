    il.DeclareLocal(typeof(TestSubject));
    
    il.Emit(OpCodes.Newobj, typeof(TestSubject).GetConstructors()[0]); // pushes a new instance of testsubject on the stack
    il.Emit(OpCodes.Stloc_0); // store the instance in local variable 0
    foreach (var prop in properties)
    {
        il.Emit(OpCodes.Ldloc_0); // load local variable 0
        il.Emit(OpCodes.Ldarg_0); // load argument 0 (the binary reader)
        il.Emit(OpCodes.Callvirt, typeof(BinaryReader).GetMethod("ReadInt32", BindingFlags.Public | BindingFlags.Instance)); // call the binary reader method (ReadInt32)
        il.Emit(OpCodes.Callvirt, prop.SetMethod); // call the setter of the property (instance of local variable 0 and return value of readint32)
    }
    il.Emit(OpCodes.Ldloc_0); // push the test subject instance
    il.Emit(OpCodes.Ret); // and return
