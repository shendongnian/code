    public class CollectionBindingModel
    {
        public int Id { get; set; }
    
        [Required]
        [Display(Name = "Center id")]
        public int CenterId { get; set; }
        public string Reference { get; set; }
        public string StatusName {get; set;}
        **public int StatusId { get; set; }**
    }
