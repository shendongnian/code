        [Display(Name = "کارفرما")]
        [Required]
        public virtual ApplicationUser Client { get; set; }
        [ForeignKey("Client")]
        public string ClientId{ get; set; }
