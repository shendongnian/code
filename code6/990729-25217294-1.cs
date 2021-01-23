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
                throw (new ArgumentException("The generic argument [<TEnum>] must be an enumeration with the [FlagsAttribute] applied.", "TEnum: " + typeof(TEnum).FullName));
            }
        }
        private static bool IsSigned<TEnum>() where TEnum : struct, TEnumBase
        {
            var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
            bool isSigned = (underlyingType == typeof(long) || underlyingType == typeof(int) || underlyingType == typeof(short) || underlyingType == typeof(sbyte));
            bool isUnsigned = (underlyingType == typeof(ulong) || underlyingType == typeof(uint) || underlyingType == typeof(ushort) || underlyingType == typeof(byte));
            if (!isSigned && !isUnsigned)
                throw new InvalidOperationException();
            return isSigned;
        }
        public static TEnum GetAll<TEnum>() where TEnum : struct, TEnumBase
        {
            ThrowOnEnumWithoutFlags<TEnum>();
            if (IsSigned<TEnum>()) 
            {
                long value = 0;
                foreach (var v in Enum.GetValues(typeof(TEnum)))
                    // Not sure I need the culture but Microsoft passes it in Enum.ToUInt64(Object value) - http://referencesource.microsoft.com/#mscorlib/system/enum.cs
                    value |= Convert.ToInt64(v, CultureInfo.InvariantCulture);
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            }
            else
            {
                ulong value = 0;
                foreach (var v in Enum.GetValues(typeof(TEnum)))
                    // Not sure I need the culture but Microsoft passes it in Enum.ToUInt64(Object value) - http://referencesource.microsoft.com/#mscorlib/system/enum.cs
                    value |= Convert.ToUInt64(v, CultureInfo.InvariantCulture);
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            }
        }
    }
