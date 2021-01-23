    public static class JsonExtensions
    {
        public static void RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                throw new ArgumentNullException();
            var contained = node.AncestorsAndSelf().Where(t => t.Parent is JArray || t.Parent is JObject).FirstOrDefault();
            if (contained != null)
                contained.Remove();
        }
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
