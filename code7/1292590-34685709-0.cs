    public class Venue
    {
      public int Id { get; set; }
      public string Name {get; set; }
      //...
      public List<Show> Shows { get; set; }
     }
    public class Show
    {
      public int Id { get; set; }
      public int VenueId { get; set; }
      [ForeignKey("VenueId")]
      public Venue Venue { get; set; }
      //...
    }
