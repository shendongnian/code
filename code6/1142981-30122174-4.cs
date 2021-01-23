    public class Enum<TEnum>
    {
        public static IEnumerable<string> GetMemberValues()
        {
            return typeof(TEnum).GetFields()
                .SelectMany(f => f.GetCustomAttributes(typeof(EnumMemberAttribute), false))
                .Cast<EnumMemberAttribute>()
                .Select(a => a.Value);
        }
    }
