    public static class EnumExtenstions
    {
        public static IEnumerable<TEnum> EnumGetOrderedValues<TEnum>(this Type enumType)
        {
            
            var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            var orderedValues = new List<Tuple<int, TEnum>>();
            foreach (var field in fields)
            {
                var orderAtt = field.GetCustomAttributes(typeof(EnumOrderAttribute), false).SingleOrDefault() as EnumOrderAttribute;
                if (orderAtt != null)
                {
                    orderedValues.Add(new Tuple<int, TEnum>(orderAtt.Order, (TEnum)field.GetValue(null)));
                }
            }
            return orderedValues.OrderBy(x=>x.Item1).Select(x=>x.Item2).ToList();
        }
    }
