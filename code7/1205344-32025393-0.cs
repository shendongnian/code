    public static bool HasImplicitConversion(Type baseType, Type targetType)
    {
        return baseType.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(mi => mi.Name == "op_Implicit" && mi.ReturnType == targetType)
            .Any(mi => {
                ParameterInfo pi = mi.GetParameters().FirstOrDefault();
                return pi != null && pi.ParameterType == baseType;
            });
    }
