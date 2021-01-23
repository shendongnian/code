    public static class Helper
    {
        public static IEnumerable<T2> ConvertRange<T1, T2>(this IEnumerable<T1> collection)
            where T1 : class
            where T2 : class, new()
        {
            List<T2> elements = new List<T2>();
            PropertyInfo[] propsT2 = typeof(T2).GetProperties();
            PropertyInfo[] propsT1 = typeof(T1).GetProperties()
                .Where(p => propsT2.Any(p2 => p2.Name == p.Name)).ToArray();
            propsT1.OrderBy(p => p.Name);
            propsT2.OrderBy(p => p.Name);
            foreach (T1 item in collection)
            {
                T2 newEl = new T2();
                for (int i = 0; i < propsT1.Length; i++)
                    propsT2[i].SetValue(newEl, propsT1[i].GetValue(item));
                elements.Add(newEl);
            }
            return elements;
        }
    }
