    public class UserEditVM : BaseViewModel
    {
      public int SelectedRoleId {set;get;}
      public IEnumerable<SelectListItem> RolesList { get; set; }
       //Other properties as needed.
    }
  
