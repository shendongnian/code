    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        public RegisterViewModel(RegisterViewModel model)
        {
            model.UserName = "user 123";
            this.UserName = model.UserName;
        }
    }
