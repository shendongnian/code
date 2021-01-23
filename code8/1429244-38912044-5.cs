    public class CategoryText
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
    
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }
        public string Name { get; set; }
    }
