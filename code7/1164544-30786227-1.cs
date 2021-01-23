    public class Suggestion {
      public int Id { get; set; } 
      public string Comment { get; set; } 
      public DateTime Time { get; set; } 
    }
    Suggestion s = new Suggestion();
    s.Time = DateTime.Now;
