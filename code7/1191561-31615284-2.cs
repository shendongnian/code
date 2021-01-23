    pubilic class ViewModel 
    {
         ObservableCollection<ViewModelDetail> Details { get; set; }
    }
    public class ViewModelDetail 
    {
         private readonly ViewModel parent;
         public class ViewModelDetail(ViewModel parent) 
         {
             this.parent = parent;
         }
     
     private string name;
     public string Name 
     {
         get{ return this.name; }
         set 
         {
            if(this.parent.Details.Where(d => d.Name == value).Count() > 0)
              SetError("Name", "Duplicate name");
           else
             this.name = value;
         }
     }      
    }
