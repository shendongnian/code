    [Route("/path/{UseOnlyOnUrl}")]
    public class Request
    {
        [IgnoreDataMember]
        public string UseOnlyOnUrl { get; set; }
        public string Data { get; set; }
    }
