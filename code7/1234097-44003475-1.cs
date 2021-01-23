    public static class JsonHelper
    {
        public static List<T> ToList<T>(string json)
        {
            ListWrapper<T> wrapper = JsonMapper.ToObject<ListWrapper<T>>(json);
            return wrapper.Items;
        }
    }
