    public class MyModel
    {
      [Required]
      public DateTime EndDate {get; set;}
      public Nullable<DateTime> StartDate {get; set;}
      public Nullable<DateTime> ValueDate {get; set;}
      public MyModel()
      {
        this.ValueDate = null;
        this.StartDate = null;
      }
    }
    
