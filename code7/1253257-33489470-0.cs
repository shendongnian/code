     public  class User
        {
            [Required(ErrorMessage = "User Name is required")]
            [Display(Name = "User Name")]
            [MaxLength(20, ErrorMessage = "The Maximum length allowed is 20 
            characters")]
            [MinLength(4, ErrorMessage = "The Minimum length is 3 characters")]
            public string Name { get; set; }
    
            [Required(ErrorMessage = "Password is required")]
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Pass { get; set; }
        }
