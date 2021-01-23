    [ElasticType(Name = "blog")]
    public class Blog
    {
        [ElasticProperty(Name = "id")]
        public int Id { get; set; }
        [ElasticProperty(Name = "title", Index = FieldIndexOption.No)]
        public string Title { get; set; }
    
        [ElasticProperty(OptOut = true)]
        public string Comments { get; set; }
    }
