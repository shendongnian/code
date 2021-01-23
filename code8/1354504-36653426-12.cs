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
                return new[] { node };
        }
        public static IEnumerable<JObject> ObjectsOrSelf(this JToken root)
        {
            if (root is JObject)
                yield return (JObject)root;
            else if (root is JContainer)
                foreach (var item in ((JContainer)root).Children())
                    foreach (var child in item.ObjectsOrSelf())
                        yield return child;
            else
                yield break;
        }
    }
