    [MetadataType(typeof(Class1Metadata))]
    public class Class1
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    [MetadataType(typeof(Class2Metadata))]
    public class Class2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Class1Metadata
    {
        [Display(Name="Id1")]
        public string Id { get; set; }
        [Display(Name = "Name1")]
        public string Name { get; set; }
    }
    public class Class2Metadata:Class1Metadata
    {
        [Display(Name = "Description2")]
        public string Description { get; set; }
    }
