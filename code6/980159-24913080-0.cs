    public interface IAttribute
    {
       string Attribute1 {get; set;}
       .
       .
       .
    }
    
    public class someVM : IAttribute
    {
      private string _name;
      public string Nam
      {
         get {return _name;}
         set
         {
            _name = value;
            NotifyPropertyChanged("Name");
                     }
      }
    
      public string Attribute1
      {
         get{return this.Name;}
         set
         {
            this.Name = value; 
            NotifyPropertyChange("Attribute1");
         }
      }
    }
