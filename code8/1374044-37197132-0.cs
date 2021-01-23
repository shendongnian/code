    public static class EnumInfo
    {
        public static T GetValues<T>() where T : struct // I (and not only) wish I could say where T : enum
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
