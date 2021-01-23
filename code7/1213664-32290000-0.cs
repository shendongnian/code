    public static ParameterExpression Parameter(Type type, string name) {
        ContractUtils.RequiresNotNull(type, "type");
 
        if (type == typeof(void)) {
            throw Error.ArgumentCannotBeOfTypeVoid();
        }
 
        bool byref = type.IsByRef;
        if (byref) {
            type = type.GetElementType();
        }
 
        return ParameterExpression.Make(type, name, byref);
    }
 
    public static ParameterExpression Variable(Type type, string name) {
        ContractUtils.RequiresNotNull(type, "type");
        if (type == typeof(void)) throw Error.ArgumentCannotBeOfTypeVoid();
        if (type.IsByRef) throw Error.TypeMustNotBeByRef();
        return ParameterExpression.Make(type, name, false);
    }
