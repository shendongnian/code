    [Validator(typeof(UserValidator))]
    public class RegisterModel : User
    {
        [Compare("Password"), Display(Name = "Confirm Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
