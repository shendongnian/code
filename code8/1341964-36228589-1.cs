    public class Foo
    {
        [MyRange(1900, ErrorMessage = "Please enter a valid year")]
        public int Year { get; set; }
    }
