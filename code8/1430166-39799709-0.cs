    public partial class YourModelClass
    {
        public string YourProperty{get;set;}
    }
    
    //Your Partial Class
    [MetadataType(typeof(YourModelClassMetaData))]
    public partial class YourModelClass
    {
    }
    
    //The class that adds your attributes
    public class YourModelClassMetaData
    {
        [Required]
        public object YourProperty{get;set;};
    }
