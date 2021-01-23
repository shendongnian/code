    public static class EnumWrapper<T> where T : struct
    {
        public static T[] Values
        {
            get
            {
                Type ofT = typeof(T);
                if (!ofT.IsEnum) throw new ArgumentException("Must be enum type");
                return Enum.GetValues(ofT).Cast<T>().ToArray();
            }
        }
    }
   // ...
    Languages[] languages = EnumWrapper<Languages>.Values;
