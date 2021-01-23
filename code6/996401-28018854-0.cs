    [DataContract]
    public class Model
    {
        [DataMember]
        [Required(ErrorMessage = "RequiredOne is required")]
        public string RequiredOne { get; set; }
    
        [DataMember]
        [StringLength(10, ErrorMessage = "Not Required should be at most 10 characters long")]
        public string NotRequired { get; set; }
    
        [DataMember]
        [Required(ErrorMessage = "ChildModel is required")]
        public List<ChildModel> ChildModel { get; set; }
    
    }
