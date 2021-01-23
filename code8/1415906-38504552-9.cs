    [TypeDescriptionProvider(typeof(MyTypeDescriptionProvider))]
    public class MySampleClass
    {
        public int Id { get; set; }
        [MySampleMetadataAttribue]
        [DisplayName("My Name")]
        public string Name { get; set; }
    }
