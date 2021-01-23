    public class ExampleModelMetadata
    {
        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday {get;set;}
    }
    
    [MetadataTypeAttribute(typeof(ExampleModelMetadata))]
    public partial class ExampleModel
    {
    }
