    public class Comment
    {
         public int CommentID { get; set; }
         [Column("TripID")]
         [ForeignKey("Trip")]
         public int TripID { get; set; }
         public virtual Trip Trip { get; set; }
         public string Text { get; set; }
    }
       
    public class CruiseComment : Comment
    {
        [Column("TripID")]
        [ForeignKey("Cruise")]
        public int CruiseID { get; set; }
        public virtual Cruise Cruise { get; set; }
    
    }
    
    public class HotelComment : Comment
    {
        [Column("TripID")]
        [ForeignKey("Cruise")]
        public int HotelID { get; set; }
    
        public virtual Hotel Hotel { get; set; }
    }
