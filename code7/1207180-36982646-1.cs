    class MyEntity
    {
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nchar")]
        public string MyEntityId { get; set; }
    }
