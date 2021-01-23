    public class TableAB
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("TableA")]
        public int id_TableA { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("TableB")]
        public int id_TableB{ get; set; }
   }
