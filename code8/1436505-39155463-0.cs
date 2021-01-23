            [Required(ErrorMessage = "Engineer name is required.")]
            [Display(Name = "Engineer")]
            [ForeignKey("engineer")]
            public int EngineerId { get; set; }
    
            [Required(ErrorMessage = "Manager is required.")]
            [Display(Name = "Manager")]
            [ForeignKey("manager")]
            public int ManagerId { get; set; }
