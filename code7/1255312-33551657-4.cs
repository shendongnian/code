    public class CreateUserVM
    {
      public int UserId {set;get;}
      public string Name {set;get;}
      public List<SelectListItem> Departments {set;get;}
      public int SelectedDept {set;get;}
 
      public CreateUserVM()
      {
        this.Departments = new List<SelectListItem>();
      }
      
    }
