        public class Rootobject
        {
            [DeserializeAs(Name = "0")]
            public SubObject _0 { get; set; }
            [DeserializeAs(Name = "1")]
            public SubObject _1 { get; set; }
            [DeserializeAs(Name = "2")]
            public SubObject _2 { get; set; }
            [DeserializeAs(Name = "3")]
            public SubObject _3 { get; set; }
            [DeserializeAs(Name = "4")]
            public SubObject _4 { get; set; }
            [DeserializeAs(Name = "5")]
            public SubObject _5 { get; set; }
            [DeserializeAs(Name = "6")]
            public SubObject _6 { get; set; }
            [DeserializeAs(Name = "7")]
            public SubObject _7 { get; set; }
            [DeserializeAs(Name = "8")]
            public SubObject _8 { get; set; }
            [DeserializeAs(Name = "9")]
            public SubObject _9 { get; set; }
            [DeserializeAs(Name = "10")]
            public SubObject _10 { get; set; }
            [DeserializeAs(Name = "11")]
            public SubObject _11 { get; set; }
            [DeserializeAs(Name = "12")]
            public SubObject _12 { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
        }
        public class SubObject
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
