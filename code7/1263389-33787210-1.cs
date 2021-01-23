    public class NameViewModel
    {
       public string FirstName { get; set; }
       public string LastName { get; set; }
    
       // There is no full name stored in the domain model but as the view requires this information in the view
       // for presentational purposes this property can be provided as a convenience
       public string FullName
       {
          get
          {
              return string.Format("{0} {1}", this.FirstName, this.LastName);
          }
       }
    }
