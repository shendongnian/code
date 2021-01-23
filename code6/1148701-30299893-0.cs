    public partial class Staff
    {
       public virtual IEnumerable<CompanyPosition> Positions { get; protected set; }
    }
    public class Position
    {
      //...
    }
   
    public class Company
    {
     //...
    }
    public class CompanyPosition
    {
      public virtual Company Company   {get;set;}
      public virtual IEnumerable<Position> {get;set;}
    }
