    public class MetricEntity : TableEntity
    {
        public MetricEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }
        public MetricEntity() { }
        public int MetricA { get; set; }
        public int MetricB { get; set; }
        public int MetricC { get; set; }
        public string UserName { get; set; }
    }
