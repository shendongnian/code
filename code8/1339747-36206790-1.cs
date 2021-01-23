    [Serializable()]
    [JsonConverter(typeof(CollectionBaseConverter<SpecificationCollection, ProjectSpec>))]
    public class SpecificationCollection : CollectionBase
    {
    }
