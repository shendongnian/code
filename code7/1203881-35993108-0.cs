    public class GridColumnAttribute : Attribute, IMetadataAware
    {
        public const string Key = "GridColumnMetadata";
        public string Width { get; set; }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[GridColumnAttribute.Key] = this;
        }
    }
