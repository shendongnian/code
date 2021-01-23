    public class CompanyViewModel
    {
      public IEnumerable<UserViewModel> Users { get; set; }
      public IEnumerable<SelectListItem> RoleList { get; set; }
    }
    public class UserViewModel
    {
      public int Id { get; set; }
      public string FirstName { get; set; }
      ....
      [Display(Name = "Roles")]
      public IEnumerable<int> SelectedRoles { get; set; }
    }
