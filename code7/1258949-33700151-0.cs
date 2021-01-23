    // Code to Generate Enum Field Metadata ...
    string enumName   = Enum.GetName(theEnumType, theOrdinalEnumValue);
    Array  enumValues = Enum.GetValues(theEnumType);
    object enumValue  = enumValues.GetValue(theOrdinalEnumValue);
    object enumObject = Enum.ToObject(theEnumType, theOrdinalEnumValue);
    // Setup the Input Parameters for calls into Enum and Array Types in preperation for Assignments
    ParameterExpression theInputOfEnumType     = Expression.Variable(typeof(Type), "theInputOfEnumType");
    ParameterExpression theEnumFieldNameValue  = Expression.Variable(typeof(string), "theEnumFieldNameValue");
    ParameterExpression aEnumObjectIndexValue  = Expression.Variable(typeof(int), "aEnumObjectIndexValue");
    ParameterExpression anArrayOfEnumObjects   = Expression.Variable(typeof(Array), "anArrayOfEnumObjects");
    ParameterExpression anEnumerableObject     = Expression.Variable(typeof(Enumerable), "anEnumerableObject");
    ParameterExpression directEnumTypeResolved = Expression.Variable(theEnumType, "directEnumTypeResolved");
    ParameterExpression fieldInfoOnEnum        = Expression.Variable(typeof(FieldInfo), "fieldInfoOnEnum");
