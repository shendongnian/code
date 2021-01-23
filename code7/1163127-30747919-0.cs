    [DataContract]
    public class Book : Product
    {
        [DataMember]
        [Required(ErrorMessage="Title is required")]
        public string Title { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Publisher is required")]
        public string Publisher { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }  
        [DataMember]      
        [Range(1, 1000)]
        public override decimal Price { get; set; }
    }
