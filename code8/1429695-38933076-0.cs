    public class RegisterViewModel
    {
        ....
        [Required(ErrorMessage = "Please select a role")]
        public string Role { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
