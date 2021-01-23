    public class EnumOrder<TEnum> where TEnum : struct
    {
        private static readonly TEnum[] Values;
        static EnumOrder()
        {
            var fields = typeof(Values).GetFields(BindingFlags.Static | BindingFlags.Public);
            Values = Array.ConvertAll(fields, x => (TEnum)x.GetValue(null));
        }
        public static int IndexOf(TEnum value)
        {
            return Array.IndexOf(Values, value);
        }
    }
