    public static class JsonExtensions
    {
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new [] { node };
        }
    }
