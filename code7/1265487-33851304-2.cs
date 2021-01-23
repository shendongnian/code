    public class CarTag
    {
        public int CarId {get;set;}
        public int TagId {get;set;}
        [ForeignKey("CarId")]
        public virtual Car Cars {get;set;}
        [ForeignKey("TagId")]
        public virtual Tag Tags {get;set;}
    }
