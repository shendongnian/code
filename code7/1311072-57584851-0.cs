    public class Person {
        [StringLength(100)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }
    }
