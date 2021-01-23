    using System.ComponentModel.DataAnnotations;
    
    namespace WebApplication1.Models
    {
        public class TestModel
        {
            [Required]
            public string Name { get; set; }
    
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }
        }
    }
