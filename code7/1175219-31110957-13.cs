    public class Person
    {
        [Required]
        [Unique(typeof(Email))]
        public Email PersonEmail { get; set; }
        [Required]
        public GenderType Gender { get; set; }
    }
    public class Email
    {
        public string EmailId { get; set; }
    }
