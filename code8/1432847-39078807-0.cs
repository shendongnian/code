    public class Bar
    {
        //This was not touched in ages, some even before adding the first migration
        [Required]
        [AssertThat(@"<Condition>", ErrorMessage = "Please revise the name")]
        public string Name { get; set; }
    }
