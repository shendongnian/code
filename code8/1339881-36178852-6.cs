    /// <summary>
    /// Helper class for analyzing a type.
    /// </summary>
    public static class TypeAnalyzer
    {
        /// <summary>
        /// Calculates if the given type is a "simple" type.
        /// </summary>
        /// <param name="type">Type to be checked for simplicity.</param>
        /// <returns>True, if the type is "simple";false otherwise.</returns>
        /// <remarks>
        ///   The following types are assumed to be simple:
        ///   <list type="*">
        ///     <item>string</item>
        ///     <item>int</item>
        ///     <item>decimal</item>
        ///     <item>float</item>
        ///     <item><see cref="StringComparison"/> (enum type)</item>
        ///     <item>int? (nullable simple types)</item> 
        ///   </list>
        ///   The following types are not simple:
        ///   <list type="*">
        ///     <item>Point (struct)</item>
        ///     <item>Point? (nullable struct)</item>
        ///     <item>StringBuilder (class)</item>
        ///   </list>
        /// </remarks>
        public static bool IsSimple(this Type type)
        {
            if (IsNullableType(type))
                return IsNestedTypeSimple(type);
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal))
              || type.Equals(typeof(DateTime))
              || type.Equals(typeof(Guid));
        }
        private static bool IsNestedTypeSimple(Type type)
        {
            var nestedType = Nullable.GetUnderlyingType(type);
            return IsSimple(nestedType);
        }
        private static bool IsNullableType(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }
    }
