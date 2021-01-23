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
        // Generic singleton remembering basic properties about specified enums, cached for performance.
        sealed class DataSingleton<TEnum> where TEnum : struct, TEnumBase
        {
            static readonly DataSingleton<TEnum> instance = new DataSingleton<TEnum>();
            readonly bool isSigned;
            readonly TEnum allValues;
            readonly bool hasFlags;
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static DataSingleton()
            {
            }
            DataSingleton()
            {
                isSigned = GetIsSigned();
                allValues = GetAll();
                hasFlags = GetHasFlags();
            }
            static bool GetHasFlags()
            {
                var attributes = typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false);
                return attributes != null && attributes.Length > 0;
            }
            static bool GetIsSigned()
            {
                var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
                bool isSigned = (underlyingType == typeof(long) || underlyingType == typeof(int) || underlyingType == typeof(short) || underlyingType == typeof(sbyte));
                bool isUnsigned = (underlyingType == typeof(ulong) || underlyingType == typeof(uint) || underlyingType == typeof(ushort) || underlyingType == typeof(byte));
                if (!isSigned && !isUnsigned)
                    throw new InvalidOperationException();
                return isSigned;
            }
            static TEnum GetAll()
            {
                if (GetIsSigned())
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
            public bool HasFlags { get { return hasFlags; } }
            public bool IsSigned { get { return isSigned; } }
            public TEnum AllValues { get { return allValues; } }
            public static DataSingleton<TEnum> Instance { get { return instance; } }
        }
        private static void ThrowOnEnumWithoutFlags<TEnum>(DataSingleton<TEnum> data) where TEnum : struct, TEnumBase
        {
            if (!data.HasFlags)
            {
                throw (new ArgumentException("The generic argument [<TEnum>] must be an enumeration with the [FlagsAttribute] applied.", "TEnum: " + typeof(TEnum).FullName));
            }
        }
        public static TEnum GetAll<TEnum>() where TEnum : struct, TEnumBase
        {
            var data = DataSingleton<TEnum>.Instance;
            ThrowOnEnumWithoutFlags<TEnum>(data);
            return data.AllValues;
        }
    }
