     public class tblInstrument
     {
    
         [Key]
         public int InstrumentID { get; set; }
         public int MarketID { get; set; }
         [ForeignKey("MarketID")]
         public virtual tblMarket tblMarket { get; set; }
    
     }
