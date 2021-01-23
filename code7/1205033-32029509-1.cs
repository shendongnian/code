    [Table("SpecialOrder")]
    public class SpecialOrder
    {
        public int SpecialOrderId { get; set; }
    
        public DateTime Date { get; set; }
    
        public int Status { get; set; }
    }
    
    [Table("ExtraSpecialOrder")]
    public class ExtraSpecialOrder : SpecialOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExtraSpecialOrderId { get; set; }
    
        public string ExtraNotes { get; set; }
    }
