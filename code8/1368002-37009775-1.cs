    @model namespace.MyViewModel 
    public class MyViewmodel {
    
      public List<SelectListItem> PersonList {get; set}
      public string SelectedPersonID {get; set}
    
      public MyViewModel(){
          PersonList = new List<SelectListItem>();
          SelectedPersonID  = "100"; //default values go here
      }
