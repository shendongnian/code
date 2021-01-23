    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class NameAttribute : Attribute
    {
        public readonly string[] Names;
        public NameAttribute(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            Names = new[] { name };
        }
        public NameAttribute(params string[] names)
        {
            if (names == null || names.Any(x => x == null))
            {
                throw new ArgumentNullException();
            }
            Names = names;
        }
    }
    public static class ParseEnum
    {
        public static TEnum Parse<TEnum>(string value) where TEnum : struct
        {
            return ParseEnumImpl<TEnum>.Values[value];
        }
        public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
        {
            return ParseEnumImpl<TEnum>.Values.TryGetValue(value, out result);
        }
        private static class ParseEnumImpl<TEnum> where TEnum : struct
        {
            public static readonly Dictionary<string, TEnum> Values = new Dictionary<string,TEnum>();
            static ParseEnumImpl()
            {
                var nameAttributes = typeof(TEnum)
                    .GetFields()
                    .Select(x => new 
                    { 
                        Value = x, 
                        Names = x.GetCustomAttributes(typeof(NameAttribute), false)
                            .Cast<NameAttribute>() 
                    });
                var degrouped = nameAttributes.SelectMany(
                    x => x.Names.SelectMany(y => y.Names), 
                    (x, y) => new { Value = x.Value, Name = y });
                Values = degrouped.ToDictionary(
                    x => x.Name, 
                    x => (TEnum)x.Value.GetValue(null));
            }
        }
    }
