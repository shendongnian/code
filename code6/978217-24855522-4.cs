    /// <summary>
    /// Contains generic utilities for enums, constrained for enums only.
    /// </summary>
    public sealed class EnumHelper : Enums<Enum>
    {
        private EnumHelper()
        {
        }
    }
    /// <summary>
    /// For use by EnumHelper, not for direct use.
    /// </summary>
    public abstract class Enums<TEnumBase> where TEnumBase : class, IConvertible
    {
        private static void ThrowOnEnumWithoutFlags<TEnum>() where TEnum : struct, TEnumBase
        {
            var attributes = typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false);
            if (attributes.Length == 0)
            {
                throw (new ArgumentException("The generic argument [<T>] must be an enumeration with the [FlagsAttribute] applied.", "T: " + typeof(TEnum).FullName));
            }
        }
        public static TEnum GetAll<TEnum>() where TEnum : struct, TEnumBase
        {
            ThrowOnEnumWithoutFlags<TEnum>();
            var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
            if (underlyingType == typeof(ulong))
            {
                ulong value = 0;
                foreach (var v in Enum.GetValues(typeof(TEnum)))
                    // Not sure I need the culture but Microsoft passes it in Enum.ToUInt64(Object value) - http://referencesource.microsoft.com/#mscorlib/system/enum.cs
                    value |= Convert.ToUInt64(v, CultureInfo.InvariantCulture); 
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            }
            else
            {
                long value = 0;
                foreach (var v in Enum.GetValues(typeof(TEnum)))
                    // Not sure I need the culture but Microsoft passes it in Enum.ToUInt64(Object value) - http://referencesource.microsoft.com/#mscorlib/system/enum.cs
                    value |= Convert.ToInt64(v, CultureInfo.InvariantCulture);
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            }
        }
