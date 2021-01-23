    // An approach to setup a Generic method call that will be used in an Expression.Assign call
    // I decompose this code so for debugging purposes
    // I create the "inputOfTSourceType" as a Generic Type because in the Definition of "SingleOrDefault" method there is only one Generic Parameter;
    // also, take special note that in the assemblage of Expression.Call methods any of the methods that take a MethodInfo instance you can't pass in
    // a "Generic" method definition. If you take a look at the code that is called it will throw and exception if it detects the IsGenericMethodDefinition
    // flag is true.
    var inputOfTSourceType  = typeof(IEnumerable<>).MakeGenericType(typeof(FieldInfo));  // This is the type on the "source" TSource parameter
    var predicateOfFuncType = typeof(Func<FieldInfo, bool>);   // This is the type on the "predicate" parameter
    // Take note there that we only define one(1) type here ("inputParameterType"); this is the type we wish apply to the Generic Type TSource
    // declaration: public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
    var inputParameterType  = new[] {typeof(FieldInfo)};       // This is the type we must match to "source" parameter
    // The "SingleOrDefault" method can take two parameters and in this case I need to pass in a lambda expression as the predicate.
    // Se we need two parameters. 
    ParameterExpression fieldInfoSource = Expression.Parameter(inputOfTSourceType, "fieldInfoSource");           // This is: this IEnumerable<TSource>
    ParameterExpression predicateSource = Expression.Parameter(predicateOfFuncType, "funcPredicateOnFieldInfo"); // This is: Func<TSource, bool> predicate
     MethodCallExpression SingleOrDefaultMethodCall = 
         Expression.Call(fieldInfoEnumerableRepresentation, // This is the Object Instance for which the 
                         "SingleOrDefault", // The Name of the Generic Method
                         inputParameterType, // The Generic Type
                         fieldInfoSource,    // this is the "this" source parameter
                         predicateSource);   // this the "predicate" parameter
     Expression localEnumNameAssignment =
       Expression.Assign(enumVariables.Variables[0], EnumGetNameMethodCall);
     Expression localEnumObjectsAssignment =
       Expression.Assign(enumVariables.Variables[1], EnumGetValauesMethodCall);
     Expression localEnumObjectAssignment =
       Expression.Assign(enumVariables.Variables[2], ArrayGetValueMethodCall);
     Expression localEnumTypeAssignment = 
       Expression.Assign(enumVariables.Variables[3], Expression.Convert(EnumToObjectMethodCall, theEnumType));
     Expression localFieldInfoAssignment =
       Expression.Assign(enumVariables.Variables[4], Expression.Convert(SingleOrDefaultMethodCall, typeof(FieldInfo)));
     BlockExpression blockExpression =
       Expression.Block(enumVariables, 
       localEnumNameAssignment, 
       localEnumObjectsAssignment, 
       localEnumObjectAssignment, 
       localEnumTypeAssignment, 
       localFieldInfoAssignment, 
       enumTypeToReturn);
