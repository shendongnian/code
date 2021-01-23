    var bf = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly ;
    // import the *generic method* from the *generic type*
    // can be done once per module
    var cwgg = module.Import (typeof (Task<>).GetMethods (bf).Where (_ =>
      _.Name == "ContinueWith"    &&
      _.IsGenericMethodDefinition &&
      _.GetParameters ().Length == 1).Single ()) ;
    // close Task<>, keep ContinueWith generic parameter open
    var cwgi     = new MethodReference (cwgg.Name, cwgg.ReturnType, taskType) ;
    cwgi.HasThis = true ;
    cwgi.GenericParameters.Add (new GenericParameter    ("TNewResult", cwgi)) ;
    cwgi.Parameters.Add        (new ParameterDefinition (
        cwgg.Parameters[0].ParameterType)) ;
    // close ContinueWith
    var continueWith = new GenericInstanceMethod (cwgi) ;
    continueWith.GenericArguments.Add      (returnType) ;
