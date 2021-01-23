    switch (type.SpecialType)
    {
        case SpecialType.System_Object:
        case SpecialType.System_ValueType:
        case SpecialType.System_Enum:
        case SpecialType.System_Delegate:
        case SpecialType.System_MulticastDelegate:
        case SpecialType.System_Array:
            // "Constraint cannot be special class '{0}'"
            Error(diagnostics, ErrorCode.ERR_SpecialTypeAsBound, syntax, type);
            return false;
    }
