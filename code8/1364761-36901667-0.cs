    public class Program
    {
        public static void Main(string[] args)
        {
            var json = @"{""key"": ""UserEmailAddress"", ""value"":""test@yahoo.com""}";
            var userObject = new JavaScriptSerializer().Deserialize<SampleObject>(json);
        }
        public class SampleObject
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    }
