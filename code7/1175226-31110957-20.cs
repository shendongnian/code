    public class Person
    {
        [Required]
        [MyValidate(typeof(IUniqueEmailCommand))]
        public string Email { get; set; }
        [Required]
        public GenderType Gender { get; set; }
    }
