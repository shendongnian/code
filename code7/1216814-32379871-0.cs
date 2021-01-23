    public class SystemUserDTO
    {
        [Display(Name = "User")]
        public string Username { get; set; }
        [Display(Name = "Admin")]
        public Nullable<bool> Type { get; set; }
    }
