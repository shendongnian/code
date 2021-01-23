    public static class EnumUtilities
    {
        public static List<T> GetValues<T> ()
            where T: struct, IComparable, IFormattable, IConvertible
        {
            EnumUtilities.ThrowOnNonEnum<T>();
            var list = Enum.GetValues(typeof(T)).OfType<T>().ToList().ConvertAll<T>(v => ((T) v));
            return (list);
        }
        private static ulong[] GetValuesAsUint64<T>()
            where T : struct, IComparable, IFormattable, IConvertible
        {
            EnumUtilities.ThrowOnNonEnum<T>();
            IList eList = Enum.GetValues(typeof(T));
            ulong[] list = new ulong[eList.Count];
            for (int i = 0; i < eList.Count; i++)
            {
                list[i] = Convert.ToUInt64(eList[i]);
            }
            return list;
        }
        public static bool IsValueDefinedOrComposite<T>(T value)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            EnumUtilities.ThrowOnEnumWithoutFlags<T>();
            var intValue = Convert.ToUInt64(value);
            var intValues = GetValuesAsUint64<T>();
            if (intValue == 0)
            {
                return intValues.Contains(intValue);
            }
            else
            {
                int matches = 0;
                foreach (var test in intValues)
                {
                    if ((test & intValue) == test)
                    {
                        matches++;
                        intValue &= ~(test);
                    }
                }
                return matches > 0 && intValue == 0;
            }
        }
        public static bool IsValueDefinedAndNonComposite<T> (T value)
            where T: struct, IComparable, IFormattable, IConvertible
        {
            EnumUtilities.ThrowOnNonEnum<T>();
            return (Enum.IsDefined(typeof(T), value));
        }
        public static bool IsValueDefinedAndComposite<T>(T value)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            return IsValueDefinedOrComposite(value) && !IsValueDefinedAndNonComposite(value);
        }
        private static void ThrowOnNonEnum<T> ()
        {
            if (!typeof(T).IsEnum)
            {
                throw (new ArgumentException("The generic argument [<T>] must be an enumeration.", "T: " + typeof(T).FullName));
            }
        }
        private static void ThrowOnEnumWithFlags<T> ()
        {
            EnumUtilities.ThrowOnNonEnum<T>();
            var attributes = typeof(T).GetCustomAttributes(typeof(FlagsAttribute), false);
            if (attributes.Length > 0)
            {
                throw (new ArgumentException("The generic argument [<T>] must be an enumeration without the [FlagsAttribute] applied.", "T: " + typeof(T).FullName));
            }
        }
        private static void ThrowOnEnumWithoutFlags<T> ()
        {
            EnumUtilities.ThrowOnNonEnum<T>();
            var attributes = typeof(T).GetCustomAttributes(typeof(FlagsAttribute), false);
            if (attributes.Length == 0)
            {
                throw (new ArgumentException("The generic argument [<T>] must be an enumeration with the [FlagsAttribute] applied.", "T: " + typeof(T).FullName));
            }
        }
    }  
