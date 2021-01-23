    class MyEntity
    {
        [Key]
        [StringLength(10, MinimumLength = 10)]
        [Column(TypeName = "nchar")]
        public string MyEntityId { get; set; }
    }
