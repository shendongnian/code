    public class baseClass
    {
        // Note I've switched your class fields to auto-properties
        [Required]
        public int Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ID { get; set; }
        protected virtual bool Validate()
        {
              List<ValidationResult> results = new List<ValidationResult>();
              // Running it for "this" executes the validator for the most derived
              // class, so this includes ALL properties (from the base class to 
              // the most derived one!
              return Validator.TryValidateObject(this, null, results);
        }
    }
