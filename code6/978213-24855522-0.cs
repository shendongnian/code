    public sealed class EnumHelper : Enums<Enum>
    {
        private EnumHelper()
        {
        }
    }
    public abstract class Enums<Temp> where Temp : class, IConvertible
    {
        private static void ThrowOnEnumWithFlags<TEnum>() where TEnum : struct, Temp
        {
            var attributes = typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false);
            if (attributes.Length > 0)
            {
                throw (new ArgumentException("The generic argument [<T>] must be an enumeration without the [FlagsAttribute] applied.", "T: " + typeof(TEnum).FullName));
            }
        }
        private static void ThrowOnEnumWithoutFlags<TEnum>() where TEnum : struct, Temp
        {
            var attributes = typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false);
            if (attributes.Length == 0)
            {
                throw (new ArgumentException("The generic argument [<T>] must be an enumeration with the [FlagsAttribute] applied.", "T: " + typeof(TEnum).FullName));
            }
        }
        public static TEnum GetAll<TEnum>() where TEnum : struct, Temp
        {
            ThrowOnEnumWithoutFlags<TEnum>();
            var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
            if (underlyingType == typeof(byte))
            {
                byte value = 0;
                foreach (byte v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else if (underlyingType == typeof(short))
            {
                short value = 0;
                foreach (short v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else if (underlyingType == typeof(ushort))
            {
                ushort value = 0;
                foreach (ushort v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else if (underlyingType == typeof(int))
            {
                int value = 0;
                foreach (int v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else if (underlyingType == typeof(uint))
            {
                uint value = 0;
                foreach (uint v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else if (underlyingType == typeof(long))
            {
                long value = 0;
                foreach (long v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else if (underlyingType == typeof(ulong))
            {
                ulong value = 0;
                foreach (ulong v in Enum.GetValues(typeof(TEnum)))
                    value |= (v);
                return (TEnum)(object)value;
            }
            else
            {
                throw new ArgumentException(string.Format("The type {0} is does not have a known Enum type", typeof(TEnum).ToString()));
            }
        }
    }
