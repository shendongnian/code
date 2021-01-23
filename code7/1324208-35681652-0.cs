        public class Meta
        {
            public int status { get; set; }
            public string msg { get; set; }
        }
        public class Blog
        {
            public string title { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
        public class TextInfo
        {
            public Meta meta { get; set; }
            public Response response { get; set; }
        }
