            [Required]
            [DataType(DataType.EmailAddress, ErrorMessage = "You need a valid email adress")]
            [MaxLength(40, ErrorMessage = "the length of an Email address must be at least 40 chars")]
            [Display(Name = "Email")]
            public string CurrentMail { get; set; }
