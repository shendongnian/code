        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Visitor Team")]               
        public Int64 VisitorID { get; set; }
        [ForeignKey("VisitorID")]
        public virtual Team Visitor { get; set; }
        
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Home Team")]        
        public Int64 HomeID { get; set; }
        [ForeignKey("HomeID")]
        public virtual Team Home { get; set; }
