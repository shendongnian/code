    public class MyModel
    {
      
      public DateTime EndDate {get; set;}
      public DateTime? StartDate {get; set;}
      public DateTime? ValueDate {get; set;}
      public MyModel()
      {
        this.ValueDate = null;
        this.StartDate = null;
      }
    }
    
