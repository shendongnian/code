    public static class TypeExtensions {
    	private static HashSet<Type> NumericTypes = new HashSet<Type> {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(IntPtr),
            typeof(UIntPtr),
        };
    
        private static HashSet<Type> NullableNumericTypes = new HashSet<Type>(
            from type in NumericTypes
            select typeof(Nullable<>).MakeGenericType(type)
        );
    
        public static bool IsNumeric(this Type @this, bool allowNullable = false) {
            return NumericTypes.Contains(@this) 
                || allowNullable && NullableNumericTypes.Contains(@this);
        }
    }
