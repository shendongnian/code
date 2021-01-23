    public class Driver 
    {
        public int Id { get; set; }
        // Make this int? if a Driver can exist without a Car
        public int CarId { get; set; }
        public virtual Car { get; set; }
    }
