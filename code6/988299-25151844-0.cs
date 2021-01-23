    public class RegisterModel
    {
        [Required]
        [UIHint("DDL")]
        [Display(Name = "User Role", Prompt = "User Role")]
        public int? RoleId { get; set; }  // important that this is nullable
        public IEnumerable<SelectListItem> UserRoles { get; set; }
    }
