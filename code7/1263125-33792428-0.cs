    public static class JsonExtensions
    {
        public static IEnumerable<JToken> LeafArrayEntries(this JContainer container)
        {
            var nonLeafEntries = new HashSet<JToken>(container.DescendantsAndSelf()
                .OfType<JArray>()
                .SelectMany(a => a.Ancestors().Where(p => p.Type != JTokenType.Property)));
            return container.DescendantsAndSelf().Where(c => c.Parent is JArray && !nonLeafEntries.Contains(c));
        }
    }
