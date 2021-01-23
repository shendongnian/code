    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"swagger\":\"2.0\",\"info\":{\"title\":\"UberAPI\",\"description\":\"MoveyourappforwardwiththeUberAPI\",\"version\":\"1.0.0\"},\"host\":\"api.uber.com\",\"schemes\":[\"https\"],\"basePath\":\"/v1\",\"produces\":[\"application/json\"]}";
            var swaggerDocument = ConvertJTokenToObject(JsonConvert.DeserializeObject<JToken>(json));
            var serializer = new YamlDotNet.Serialization.Serializer();
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, swaggerDocument);
                var yaml = writer.ToString();
                Console.WriteLine(yaml);
            }
        }
        static object ConvertJTokenToObject(JToken token)
        {
        	if (token is JValue)
        		return ((JValue)token).Value;
        	if (token is JArray)
        		return token.AsEnumerable().Select(ConvertJTokenToObject).ToList();
        	if (token is JObject)
        		return token.AsEnumerable().Cast<JProperty>().ToDictionary(x => x.Name, x => ConvertJTokenToObject(x.Value));
        	throw new InvalidOperationException("Unexpected token: " + token);
        }
    }
