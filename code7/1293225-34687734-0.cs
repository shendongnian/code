    public class Event {
      [Key]
      public int Id { get; set; }
    
      public string Title { get; set; }
    
      //this line was missing in my original post
      //and that's the one that was confusing entity framework
      public ICollection<EventAction> Actions { get; set; }
    
    }
