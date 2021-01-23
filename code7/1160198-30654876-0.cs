        public static IEnumerable<TEnum> EnumGetOrderedValues<TEnum>(Type enumType)
        {
            var fields = typeof(MyEnum).GetFields(BindingFlags.Public | BindingFlags.Static);
            var orderedValues = new TEnum[fields.Length];
            foreach (var field in fields)
            {
                var orderAtt = field.GetCustomAttributes(typeof(OrderAttribute), false).SingleOrDefault() as OrderAttribute;
                if (orderAtt != null)
                {
                    orderedValues[orderAtt.Order] = (TEnum)field.GetValue(null);
                }
            }
            return orderedValues;
        }
