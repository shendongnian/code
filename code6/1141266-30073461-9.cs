    public class AModel
    {
        [DisplayName("Email")]
        [Remote("VerifyUserEmail", "Home")]
        public string User_Email { get; set; }
    }
