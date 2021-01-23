    [ElasticsearchType(Name = "cases")]
	public class Case
	{
        public Case()
        {
        }
        [String(Name = "case_name")]
		public string CaseName { get; set; }
        [String(Name = "md5")]
        public string Md5 { get; set; }
		
		[Attachment(Name="file")]
		public Attachment File { get; set; }
	}
	public class Attachment
	{
        public Attachment()
        {
                
        }
        [String(Name = "_author")]
        public string Author { get; set; }
        [String(Name = "_content_lenght")]
        public long ContentLength { get; set; }
        [String(Name = "_content_type")]
        public string ContentType { get; set; }
        [Date(Name = "_date")]
        public DateTime Date { get; set; }
        [String(Name = "_keywords")]
        public string Keywords { get; set; }
        [String(Name = "_language")]
        public string Language { get; set; }
        [String(Name = "_name")]
        public string Name { get; set; }
        [String(Name = "_title")]
        public string Title { get; set; }
        [String(Name = "_content")]
        public string Content { get; set; }
    }
