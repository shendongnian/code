    namespace YOUR_SOLUTION_NAME.Models
    {
        public class testModel
        {
    
            [Required(ErrorMessage = "Please attached the personal photo")]
            [ValidImageFile(ErrorMessage = "The file is not a valid image file")]
            public HttpPostedFileBase File { get; set; }
    
        }
    }
