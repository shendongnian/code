    public static class Helper
    {
        public static Dictionary<T1, T2> ToDictionary<T1, T2>(this IEnumerable<object> dict, string key, string value)
        {
            Dictionary<T1, T2> meowDict = new Dictionary<T1, T2>();
            foreach (object item in dict)
                meowDict.Add((T1)item.GetType().GetProperty(key).GetValue(item),
                    (T2)item.GetType().GetProperty(value).GetValue(item));
            return meowDict;
        }
    }
