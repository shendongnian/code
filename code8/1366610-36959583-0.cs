            var root = new JObject(new JProperty("response", new JRaw(jsonLiteral)));
            var rootJson = root.ToString();
    can be done instead of the less-efficient:
            var root = new JObject(new JProperty("response", JToken.Parse(jsonLiteral)));
    It's also possible to deserialize to `JRaw` to capture a JSON hierarchy as a single string literal, though I don't see much use in doing so.  For instance, given the class:
        public class RootObject
        {
            public JRaw response { get; set; }
        }
    One can do:<p>
            var rootDeserialized = JsonConvert.DeserializeObject<RootObject>(rootJson);
            var jsonLiteralDeserialized = (string)rootDeserialized.response;
    However, this is not necessarily more efficient than deserializing to a `JToken`.
