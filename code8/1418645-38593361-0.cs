    public static class SerializationExtensions
    {
        static bool EnumTypeIsSigned(this Type tEnum)
        {
            var underlyingType = Enum.GetUnderlyingType(tEnum);
            if (underlyingType == typeof(long) || underlyingType == typeof(int) || underlyingType == typeof(short) || underlyingType == typeof(sbyte))
                return true;
            if (underlyingType == typeof(ulong) || underlyingType == typeof(uint) || underlyingType == typeof(ushort) || underlyingType == typeof(byte))
                return false;
            throw new ArgumentException(tEnum.Name + " is not an enum type");
        }
        static bool IsSigned<TEnum>(this TEnum value) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return typeof(TEnum).EnumTypeIsSigned();
        }
        public static void WriteEnum<TEnum>(this BinaryWriter writer, TEnum value) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (value.IsSigned())
            {
                var underlyingValue = checked(value.ToInt64(NumberFormatInfo.InvariantInfo));
                writer.Write(underlyingValue);
            }
            else
            {
                var underlyingValue = checked(value.ToUInt64(NumberFormatInfo.InvariantInfo));
                writer.Write(underlyingValue);
            }
        }
        public static TEnum ReadEnum<TEnum>(this BinaryReader reader) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (typeof(TEnum).EnumTypeIsSigned())
            {
                var underlyingValue = reader.ReadInt64();
                return checked((TEnum)Enum.ToObject(typeof(TEnum), underlyingValue));
            }
            else
            {
                var underlyingValue = reader.ReadUInt64();
                return checked((TEnum)Enum.ToObject(typeof(TEnum), underlyingValue));
            }
        }
    }
