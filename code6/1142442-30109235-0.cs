    public static class Json35Extensions
    {
        public static JObject ParseObject(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                var startDepth = reader.Depth;
                var obj = JObject.Load(reader);
                if (startDepth != reader.Depth)
                    throw new JsonSerializationException("unclosed json found");
                return obj;
            }
        }
        public static JArray ParseArray(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                var startDepth = reader.Depth;
                var obj = JArray.Load(reader);
                if (startDepth != reader.Depth)
                    throw new JsonSerializationException("unclosed json found");
                return obj;
            }
        }
    }
