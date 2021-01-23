    public class CreateUserVm
    {       
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public HttpPostedFileBase UserImage { get; set; }
    }
