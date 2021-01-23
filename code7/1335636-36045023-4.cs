        var path = "$.[?(@.value)]";
        var tokens = jt.SelectTokens(path, false)
            .Where(t => !t["value"].IsNull());
    using the extension method:
        public static class JsonExtensions
        {
            public static bool IsNull(this JToken token)
            {
                return token == null || token.Type == JTokenType.Null;
            }
        }
