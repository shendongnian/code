    public class CommentFormModel
    {
        public int ID { get; set; }
    
        [Display(Name = "Your name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string Name { get; set; }
    
        [Display(Name = "Your email? (optional)"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    
        [AllowHtml]
        [Display(Name = "Content")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        public string Content { get; set; }
    }
