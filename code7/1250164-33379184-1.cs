    public class RegisterModel
    {
        // put username validation rules here
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password does not match.")]
        public string Confirmpassword { get; set; }
        ...
        public RegisterTable Map()
        {
            var v = new Rfc2898DeriveBytes(this.Password, 16, 3987);
            return new RegisterTable()
            {
                
                Salt = Convert.ToBase64String(v.Salt, Base64FormattingOptions.None),
                tPassword = Convert.ToBase64String(v.GetBytes(25), Base64FormattingOptions.None),
                tUserName = this.UserName
            };
        }
    }
