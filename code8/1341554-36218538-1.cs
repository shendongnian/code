    public static class ExtentionMethods
    {
        public static WebSocketCollection ToCollection(this IEnumerable<WebSocketHandler> handlers)
        {
            var collection = new WebSocketCollection();
            foreach (var item in handlers)
            {
                collection.Add(item);
            }
            return collection;
        }
    }
