        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        //Gemification
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Yens { get; set; }
        //Application
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<OwnedGroup> OwnedGroups { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
