    [Key]
    [Column(Order = 0)] 
    [DatabaseGenerated(DatabaseGeneratedOption.None)] 
    [Range(0, Int32.MaxValue, ErrorMessage = "Value for {0} must be larger than 0.")]
    public int Customer_ID { get; set; }
