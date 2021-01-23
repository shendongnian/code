    public static class JsonExtensions
    {
        public static IList<JToken> ChildrenTokenList(this JContainer container)
        {
            return container;
        }
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            // Small wrapper adding this method to all JToken types.
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new[] { node };
        }
        public static JToken MapValues(this JToken root, Func<JValue, JValue> map)
        {
            if (map == null || root == null)
                throw new ArgumentNullException();
            if (root is JValue)
                return map((JValue)root);
            else
            {
                root = root.DeepClone();
                foreach (var container in root.DescendantsAndSelf().OfType<JContainer>())
                {
                    var children = container.ChildrenTokenList();
                    for (int i = 0, n = children.Count; i < n; i++)
                        if (children[i] is JValue)
                            children[i] = map((JValue)children[i]);
                }
                return root;
            }
        }
        public static JToken MapValuesToValueTypes(this JToken root)
        {
            return root.MapValues(v => (v.Type == JTokenType.Null ? (JValue)null : (JValue)v.Type.ToString()));
        }
    }
