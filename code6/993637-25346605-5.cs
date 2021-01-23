    public class User
    {
        public User() { }
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountId { get; set; }
    }
    public class UserDto
    {
        public UserDto() { }
        public UserDto(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            AccountId = user.AccountId;
        }
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountId { get; set; }
    }
