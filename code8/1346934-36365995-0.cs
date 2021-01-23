    public class CustOrder
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CoLines")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDER_NBR { get; set; }
        public virtual ICollection<CoLine> CoLines { get; set; }
    }
