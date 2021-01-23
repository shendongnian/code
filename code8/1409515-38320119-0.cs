    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    namespace YouProjectName.Models
    {
        public class AccountLoginModel
        {
            [Required]
            public string Username { get; set; }
    
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    
            [HiddenInput(DisplayValue = false)]
            public string ReturnUrl { get; set; }
        }
    }
