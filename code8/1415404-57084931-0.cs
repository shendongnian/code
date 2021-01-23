    public static class MethodInfoExt {
        const int IL_ldarg0 = 0x02;
        const int IL_ldfld = 0x7B;
    
        public static FieldInfo FieldInfoFromGetAccessor(this MethodInfo getAccessorMI) {
            var body = getAccessorMI.GetMethodBody().GetILAsByteArray();
            if (body[0] == IL_ldarg0 && body[1] == IL_ldfld) {
                var fieldToken = BitConverter.ToInt32(body, 2);
                return getAccessorMI.DeclaringType.Module.ResolveField(fieldToken);
            }
            else
                return default;
        }    
    }
