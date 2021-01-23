    // Code to Generate Enum Field Metadata ...
    string enumName   = Enum.GetName(theEnumType, theOrdinalEnumValue);
    Array  enumValues = Enum.GetValues(theEnumType);
    object enumValue  = enumValues.GetValue(theOrdinalEnumValue);
    object enumObject = Enum.ToObject(theEnumType, theOrdinalEnumValue);
    // Create Local variables of the types targeted for assignment expressions that we will make in the generated code
    var enumVariables = Expression.RuntimeVariables(Expression.Variable(typeof(string), "gcEnumName"),
                                                    Expression.Variable(typeof(Array), "gcEnumValues"),
                                                    Expression.Variable(typeof(object), "gcEnumValue"),
                                                    Expression.Variable(theEnumType, "gcEnumObject"),
                                                    Expression.Variable(typeof(FieldInfo), "gcFieldInfoOnEnum"));
    // Setup the Input Parameters for calls into Enum and Array Types in preperation for Assignments
    ParameterExpression theInputOfEnumType     = Expression.Variable(typeof(Type), "theInputOfEnumType");
    ParameterExpression theEnumFieldNameValue  = Expression.Variable(typeof(string), "theEnumFieldNameValue");
    ParameterExpression aEnumObjectIndexValue  = Expression.Variable(typeof(int), "aEnumObjectIndexValue");
    ParameterExpression anArrayOfEnumObjects   = Expression.Variable(typeof(Array), "anArrayOfEnumObjects");
    ParameterExpression anEnumerableObject     = Expression.Variable(typeof(Enumerable), "anEnumerableObject");
    ParameterExpression directEnumTypeResolved = Expression.Variable(theEnumType, "directEnumTypeResolved");
    ParameterExpression fieldInfoOnEnum        = Expression.Variable(typeof(FieldInfo), "fieldInfoOnEnum");
    var fieldInfoEnumerableRepresentation = typeof(Enumerable);
