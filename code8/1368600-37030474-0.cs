    [Table("CustomerCall")]
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
        //This is your navigation property
        [ForeignKey("Status")]
        public virtual CallStatus CallStatus { get; set; }
    }
