    var generic_argument =
        some_type
        .GetGenericArguments()[0]; //This will give you the generic argument which is T in your example.
    var generic_parameter_constraints =
        generic_argument
        .GetGenericParameterConstraints(); //This will give you an array of types that present the type constraints on the generic argument T
