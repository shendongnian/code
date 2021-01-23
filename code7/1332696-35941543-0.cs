    public interface IParent
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Address { get; set; }
        string Town { get; set; }
        string Password { get; set; }
    }
    public class ShoppingParent : IParent
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Password { get; set; }
    }
    public class PasswordRequiredParent : IParent
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        [Required]
        public string Password { get; set; }
    }
