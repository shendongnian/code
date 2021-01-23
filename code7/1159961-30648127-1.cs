    public class FirstViewModel
    {
        [Required]
        public SecondViewModel SecondViewModel { get; set; }
    }
    public class SecondViewModel
    {
        [Range(1, 12)]
        public int month { get; set; }
    }
