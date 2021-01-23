    public static bool IsImplicitFrom(this Type type, Type fromType) {
        if (type == null || fromType == null) {
            return false;
        }
    
        // support for reference type
        if (type.IsByRef) { type = type.GetElementType(); }
        if (fromType.IsByRef) { fromType = type.GetElementType(); }
    
        // could always be convert to object
        if (type.Equals(typeof(object))) {
            return true;
        }
    
        // check if it could be convert using standard implicit cast
        if (IsStandardImplicitFrom(type, fromType)) {
            return true;
        }
    
        // determine implicit convert operator
        Type nonNullalbeType, nonNullableFromType;
        if (IsNullableType(type, out nonNullalbeType) && 
            IsNullableType(fromType, out nonNullableFromType)) {
            type = nonNullalbeType;
            fromType = nonNullableFromType;
        }
    
        return ConversionCache.GetImplicitConversion(fromType, type) != null;
    }
    
    internal static bool IsStandardImplicitFrom(this Type type, Type fromType) {
        // support for Nullable<T>
        if (!type.IsValueType || IsNullableType(ref type)) {
            fromType = GetNonNullableType(fromType);
        }
    
        // determine implicit value type convert
        HashSet<TypeCode> typeSet;
        if (!type.IsEnum && 
            ImplicitNumericConversions.TryGetValue(Type.GetTypeCode(type), out typeSet)) {
            if (!fromType.IsEnum && typeSet.Contains(Type.GetTypeCode(fromType))) {
                return true;
            }
        }
    
        // determine implicit reference type convert and boxing convert
        return type.IsAssignableFrom(fromType);
    }
