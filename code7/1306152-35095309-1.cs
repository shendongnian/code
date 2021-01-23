    class TableEntity
    {
        public string PartitionKey {get; set;}
        public string RowKey {get; set;}
    }
    
    [MetadataType(typeof(MyEntityMeta))]
    class MyEntity : TableEntity
    {
        public string AField {get; set;}
    }
    
    public class MyEntityMeta
    {
        [JsonProperty(PropertyName = "GroupID")]
        public string PartitionKey {get; set;}
    
        [JsonProperty(PropertyName = "myAFieldName")]
        public string AField {get; set;}
    }
