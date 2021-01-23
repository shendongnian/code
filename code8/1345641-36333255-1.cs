        [XmlRoot(ElementName = "condition", Namespace = "http://xml.weather.yahoo.com/ns/rss/1.0")]
        public class Condition
        {
            [XmlAttribute(AttributeName = "yweather", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Yweather { get; set; }
            [XmlAttribute(AttributeName = "code")]
            public string Code { get; set; }
            [XmlAttribute(AttributeName = "date")]
            public string Date { get; set; }
            [XmlAttribute(AttributeName = "temp")]
            public string Temp { get; set; }
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "item")]
        public class Item
        {
            [XmlElement(ElementName = "condition", Namespace = "http://xml.weather.yahoo.com/ns/rss/1.0")]
            public Condition Condition { get; set; }
        }
        [XmlRoot(ElementName = "channel")]
        public class Channel
        {
            [XmlElement(ElementName = "item")]
            public Item Item { get; set; }
        }
        [XmlRoot(ElementName = "results")]
        public class Results
        {
            [XmlElement(ElementName = "channel")]
            public Channel Channel { get; set; }
        }
        [XmlRoot(ElementName = "query")]
        public class Query
        {
            [XmlElement(ElementName = "results")]
            public Results Results { get; set; }
            [XmlAttribute(AttributeName = "yahoo", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Yahoo { get; set; }
            [XmlAttribute(AttributeName = "count", Namespace = "http://www.yahooapis.com/v1/base.rng")]
            public string Count { get; set; }
            [XmlAttribute(AttributeName = "created", Namespace = "http://www.yahooapis.com/v1/base.rng")]
            public string Created { get; set; }
            [XmlAttribute(AttributeName = "lang", Namespace = "http://www.yahooapis.com/v1/base.rng")]
            public string Lang { get; set; }
        }
