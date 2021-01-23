    [ElasticType(Name = "importFile")]
    public class ImportFile
    {
        [ElasticProperty(Store = false, Index = FieldIndexOption.NotAnalyzed)]
        public string FileName { get; set; }
    
        [ElasticProperty(Store = false, Index = FieldIndexOption.NotAnalyzed)]
        public string GroupId { get; set; }
    
        [ElasticProperty(Store = true, Index = FieldIndexOption.Analyzed)]
        public string FilePath { get; set; }
    }
