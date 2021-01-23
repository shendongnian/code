    class MessageAttribute : Attribute {
        public string Url { get; }
        public string Description { get; }
        public MessageAttribute(string url, string description = null) {
            Url = url;
            Description = description;
        }
    }
    class RespondsWithAttribute : Attribute {
        public Type Type { get; }
        public RespondsWithAttribute(Type type) {
            Type = type;
        }
    }
