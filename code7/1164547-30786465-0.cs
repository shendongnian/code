    public class Suggestion 
    {
      public DateTime WhenCreated { get; set; }
      /* other props */
    
      public Suggestion() 
      {
        WhenCreated = DateTime.Now;
      }
    }
