    public class Attendance
    {
      public int Id { get; set; }
      public Nullable<System.DateTime> StartDateTime { get; set; }
      public Nullable<System.DateTime> EndDateTime { get; set; }
      public TimeSpan Duration 
      { 
           get 
           { 
               if (StartDateTime.HasValue && EndDateTime.HasValue)
               {
                   return (EndDateTime.Value - StartDateTime.Value);
               }
               else {...}
           }
    }
