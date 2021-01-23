    public class Dave
    {
        [Required, MinLength(2)]
        public string Username { get; set; }
        [DataType(DataType.Password), Required]
        public string Password { get; set; }
    }
