        static ulong ToUInt64<TEnum>(TEnum value) where TEnum : struct, IConvertible
        {
            // Silently convert the value to UInt64 from the other base 
            // types for enum without throwing an exception.
            // This is need since the Convert functions do overflow checks.
            TypeCode typeCode = value.GetTypeCode();
            ulong result;
            switch (typeCode)
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    result = (UInt64)value.ToInt64(CultureInfo.InvariantCulture);
                    break;
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    result = value.ToUInt64(CultureInfo.InvariantCulture);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return result;
        }
