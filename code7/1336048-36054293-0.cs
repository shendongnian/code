        [JsonObject(MemberSerialization.OptIn)]
        public class Person
        {
            // "John Smith"
            [JsonProperty]
            public string Name { get; set; }
            // "2000-12-15T22:11:03"
            [JsonProperty]
            public DateTime BirthDate { get; set; }
        
            // new Date(976918263055)
            [JsonProperty]
            [JsonConverter(typeof(JavaScriptDateTimeConverter))]
            public DateTime LastModified { get; set; }
        
            // not serialized because mode is opt-in
            public string Department { get; set; }
        }
