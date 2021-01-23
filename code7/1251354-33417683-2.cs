    public class CreateUser
    {
      public string UserName {set;get;}
      public string Password{set;get;}
      public List<SelectListItem> RolesList {set;get;}
      public int SelectedRoleId {set;get;}
    }
