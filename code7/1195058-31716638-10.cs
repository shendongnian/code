    public class TestModel
    {
        public IList<Test> list
        { get; set; }
    }
    public class Test
    {        
            [Display(Name = "A")]
            [Range(1, 2147483647)]
            [Required]        
            public int A { get; set; }
            [Display(Name = "B")]
            [Range(0, 2147483647)]
            [Required]
            public int B { get; set; }
    }
