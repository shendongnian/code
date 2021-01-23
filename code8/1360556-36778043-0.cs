    public class YourModel
    {
        [RegularExpression(@"[^\w\s\w$]", ErrorMessage = "You must have exactly two words separated by a space.")]
        public string YourProperty { get; set; }
    }
