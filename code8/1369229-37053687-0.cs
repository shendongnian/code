    public partial class CustomerCall
        {
            public int Id { get; set; }
    
            [StringLength(50)]
            public string CustomerName { get; set; }
    
            [StringLength(50)]
            public string Subject { get; set; }
    
            [Column(TypeName = "text")]
            public string Comment { get; set; }
    
            public DateTime? CallDate { get; set; }
    
            public int? Status { get; set; }
    
            public int? AssignedTo { get; set; }
    
            public DateTime? CreateDate { get; set; }
    
            [ForeignKey("Status")]
            public CallStatus CallStatus { get; set; }
    
        }
    
    public partial class CallStatus
        {
            [Key]
            public int Id { get; set; }
    
            [StringLength(25)]
            public string StatusName { get; set; }
        }
