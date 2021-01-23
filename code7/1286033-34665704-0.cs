    public class User : IUser
    {
        public User()
        {
        }
        public User(User user){} //this is the problem line
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="You must supply a Username")]
        [DataType(DataType.Text)]
        public string Username { get; private set; }
        [Required(ErrorMessage = "You must enter a valid password to Login!")]
        public SecureString Password { get; private set; }
        [DataType(DataType.Time)]
        [Required]
        public TimeSpan TimeLoggedIn { get; private set; }
        [DataType(DataType.Date)]
        public DateTime LoginHistory { get; private set; }
        public void SetUserDetails(string username, TimeSpan date, DateTime History)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("You cannot have any of the Login Fields empty..!");
            }
            Username = username;
            TimeLoggedIn = date;
            LoginHistory = History;
        }
    }
