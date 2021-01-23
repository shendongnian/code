    public static class EnumUtils
    {
        public static bool IsObsolete<TEnumType>(TEnumType value) where TEnumType : struct
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (ObsoleteAttribute[])
                fi.GetCustomAttributes(typeof(ObsoleteAttribute), false);
            return (attributes != null && attributes.Length > 0);
        }
        public static List<TEnumType> GetObsoleteValues<TEnumType>() where TEnumType : struct
        {
            return GetAllValues<TEnumType>().Where(e => IsObsolete(e)).ToList();
        }
        public static List<TEnumType> GetNonObsoleteValues<TEnumType>() where TEnumType : struct
        {
            return GetAllValues<TEnumType>().Where(e => !IsObsolete(e)).ToList();
        }
        public static List<TEnumType> GetAllValues<TEnumType>() where TEnumType : struct
        {
            return Enum.GetValues(typeof(TEnumType)).Cast<TEnumType>().ToList();
        }
    }
