    public class ContactModel
    {
        [Required]
        [CannotBeRed(ErrorMessage = "Not red!")]
        public string Message { get; set; }
    }
