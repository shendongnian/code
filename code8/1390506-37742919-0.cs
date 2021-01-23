    [ElasticsearchType(Name = "blogpost", IdProperty = "Id")]
    public class BlogPost
    {
        [String]
        public Guid Id { get; set; }
    
        [String]
        public string Title { get; set; }
    
        [String(Analyzer = "english", TermVector = TermVectorOption.WithOffsets)]
        public string Body { get; set; }
    }
    client.CreateIndex("blogposts", c => c
        .Mappings(m => m
            .Map<BlogPost>(mm => mm
                .AutoMap()
            )
        )
    );
