    public class RegisterModel
    {
        [Required]
        [UIHint("DDL")]
        [Display(Name = "User Role", Prompt = "User Role")]
        public int? RoleId { get; set; }  // important that this is nullable
        [Required]
        [UIHint("DDL")]
        [Display(Name = "User Role 2", Prompt = "User Role 2")]
        public int? RoleId2 { get; set; }  // important that this is nullable
        public IEnumerable<SelectListItem> UserRoles { get; set; }
    }
