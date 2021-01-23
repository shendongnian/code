    public class AdminViewModel
    {
        public SelectList RoleTypes { get; set; }
        public List<UserRoleViewModel> UserRoles { get; set; }
    }
    public class UserRoleViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Role")]
        [Required(ErrorMesage = "Please select a role"`enter code here`)]
        public int SelectedRole { get; set; }
    }
