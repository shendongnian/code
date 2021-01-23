    [Nest.ElasticsearchType]
    public class MyType
    {
        // Index this & allow for retrieval.
        [Nest.Number(Store=true)]
        int Id { get; set; }
        // Index this & allow for retrieval.
        // **Also**, in my searching & sorting, I need to sort on this **entire** field, not just individual tokens.
        [Nest.String(Store = true, Index=Nest.FieldIndexOption.Analyzed, TermVector=Nest.TermVectorOption.WithPositionsOffsets)]
        string CompanyName { get; set; }
        
        // Don't index this for searching, but do store for display.
        [Nest.Date(Store=true, Index=Nest.NonStringIndexOption.No)]
        DateTime CreatedDate { get; set; }
        // Index this for searching BUT NOT for retrieval/displaying.
        [Nest.String(Store=false, Index=Nest.FieldIndexOption.Analyzed)]
        string CompanyDescription { get; set; }
        [Nest.Nested(Store=true, IncludeInAll=true)]
        // Nest this.
        List<MyChildType> Locations { get; set; }
    }
    [Nest.ElasticsearchType]
    public class MyChildType
    {
        // Index this & allow for retrieval.
        [Nest.String(Store=true, Index = Nest.FieldIndexOption.Analyzed)]
        string LocationName { get; set; }
        // etc. other properties.
    }
