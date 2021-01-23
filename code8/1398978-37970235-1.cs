        [Display(Name = "کارفرما")]
        public virtual ApplicationUser Client { get; set; }
        [ForeignKey("Client")]
        [Required] //**** Right Place for required annotation****
        public string ClientId{ get; set; }
