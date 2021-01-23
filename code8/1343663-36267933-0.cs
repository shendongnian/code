    public class Period : IEquatable<Period>
    {
         public DateTime StartDate { get; set; }
         public DateTime EndDate { get; set; }
         public bool Equals(Period other)
         {
             return StartDate == other.StartDate && EndDate == other.EndDate;
         }
    }
