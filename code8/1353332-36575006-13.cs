    public class ContactModel
    {
        [CannotBeRed(ErrorMessage = "Red is not allowed!")]
        public string Message { get; set; }
    }
