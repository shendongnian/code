        public static bool IsValueDefinedAndComposite<T>(T value)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            EnumUtilities.ThrowOnNonEnum<T>();
            var valueAsString = Enum.Format(typeof (T), value, "F");
            // If the value contains a comma, then it is defined and composite
            if (valueAsString.Contains(","))
            {
                return true;
            }
            else
            {
                // If the value cannot be completely determined by the enumeration entries, it will be numeric. 
                // This is one possible method for testing this.
                double valueAsDouble = 0;
                return !(Double.TryParse(valueAsString, out valueAsDouble));
            }
        }
