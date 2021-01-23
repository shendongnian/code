    /// <summary>
    /// Maps Tag class properties to the CSV columns' names
    /// </summary>
    public sealed class TagMap : ClassMap<Tag>
    {
        public TagMap(ILogger<CsvImporter> logger)
        {
            Map(tag => tag.Aggregate).Name("aggregate").TypeConverter<AggregateEnumConverter<AggregateType>>();
        }
    }
