    public partial class Order
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MasterFID { get; set; }
    
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ID { get; set; }
    
        [StringLength(50)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Number { get; set; }
    
        public int? OutletID { get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? OrderDate { get; set; }
    
        [StringLength(250)]
        public string Comment { get; set; }
    
        public decimal? Sum { get; set; }
