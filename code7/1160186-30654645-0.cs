    [AttributeUsage(AttributeTargets.Field)]
    public class OrderAttribute : Attribute
    {
        public readonly int Order;
        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
    public static class OrderHelper
    {
        public static int GetOrder<TEnum>(TEnum value) where TEnum : struct
        {
            int order;
            if (!OrderHelperImpl<TEnum>.Values.TryGetValue(value, out order))
            {
                order = int.MaxValue;
            }
            return order;
        }
        private static class OrderHelperImpl<TEnum>
        {
            public static readonly Dictionary<TEnum, int> Values;
            static OrderHelperImpl()
            {
                var values = new Dictionary<TEnum, int>();
                var fields = typeof(TEnum).GetFields(BindingFlags.Static | BindingFlags.Public);
                int unordered = int.MaxValue - 1;
                for (int i = fields.Length - 1; i >= 0; i--)
                {
                    FieldInfo field = fields[i];
                    var order = (OrderAttribute)field.GetCustomAttributes(typeof(OrderAttribute), false).FirstOrDefault();
                    int order2;
                    if (order != null)
                    {
                        order2 = order.Order;
                    }
                    else
                    {
                        order2 = unordered;
                        unordered--;
                    }
                    values[(TEnum)field.GetValue(null)] = order2;
                }
                Values = values;
            }
        }
    }
