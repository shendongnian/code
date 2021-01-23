    public class CreateUserVm
    {
        public string UserName { set; get; }
        public IEnumerable<RoleVm> Roles { set; get; } 
        public int SelectedRole { set; get; }
    }
    public class RoleVm
    {
        public int Id { set; get; }
        public string RoleName { set; get; }        
    }
