        [JsonConverter(typeof(JsonSubtypes), "TypeName")]
        [JsonSubtypes.KnownSubType(typeof(Type1), "Type1")]
        [JsonSubtypes.KnownSubType(typeof(Type2), "Type2")]
        public interface IPoco
        {
            string TypeName { get; }
        }
        public class Type1 : IPoco
        {
            public string TypeName { get; } = "Type1";
            /* ... */
        }
        public class Type2 : IPoco
        {
            public string TypeName { get; } = "Type2";
            /* ... */
        }
