    public static KeyValuePair<string, List<KeyValueDataItem>> ConvertEnumWithDescription<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Type given T must be an Enum");
            }
            var enumType = typeof(T).ToString().Split('.').Last();
            var itemsList = Enum.GetValues(typeof(T))
                  .Cast<T>()
                   .Select(x => new KeyValueDataItem
                   {
                       Key = Convert.ToInt32(x),
                       Value = GetEnumDescription<T>(x.ToString())
                   })
                   .ToList();
            var res = new KeyValuePair<string, List<KeyValueDataItem>>(
                enumType, itemsList);
            return res;
        }
        public static string GetEnumDescription<T>(string value)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();
            if (name == null)
            {
                return string.Empty;
            }
            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
    }
