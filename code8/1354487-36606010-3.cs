         public class Values
        {
            public object value { get; set; }
        }
        public class CustomField
        {
            public string name { get; set; }
            public string type { get; set; }
            public Values values { get; set; }
        }
        public class CustomFields
        {
            public List<CustomField> customField { get; set; }
        }
        public class Security
        {
            public string id { get; set; }
            public string sedol { get; set; }
            public CustomFields customFields { get; set; }
        }
        public class Securities
        {
            public Security Security { get; set; }
        }
        public class Issuer
        {
            public string id { get; set; }
            public string name { get; set; }
            public string clientCode { get; set; }
            public Securities securities { get; set; }
        }
        public class DataFeed
        {
            public string FeedName { get; set; }
            public List<Issuer> Issuer { get; set; }
        }
        public class RootObject
        {
            public DataFeed DataFeed { get; set; }
        }
