    public sealed class JsonContent : StringContent
    {
        public JsonContent(object content)
            : base(JsonConvert.SerializeObject(content))
        {
        }
        public JsonContent(object content, Encoding encoding)
            : base(JsonConvert.SerializeObject(content), encoding, "application/json")
        {
        }
    }
