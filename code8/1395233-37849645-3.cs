    public abstract class Employee
    {
        public virtual string Title 
        { 
            get { return GetType().Name; }
         }
    }
    public class Partner : Director {
    {
          public Partner()  
          {
             this._jobTitle = SpecificTitle.Partner;  // defaults to Partner
          } 
           public Partner(SpecificTitle jobTitle) 
           {
              this._jobTitle = jobTitle;  // overloaded ctor allows user to specify
           }
         public override string Title { get {return GetJobTitle();}  
 
          public enum SpecificTitle
          {
              Principal,
              Partner
          };
           private SpecificTitle _jobTitle;
      
          private string GetJobTitle()
          {
              switch (_jobTitle)
               {
                 case SpecificTitle.Principal:
                   return "Principal";
                 case SpecificTitle.Partner:
                 default:
                   return  "Partner";
                }
            }
        }
         
    }
