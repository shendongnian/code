    public class User
    {
        public string Name { get; set; }
        public string Passord { get; set; }
        public  string Email { get; set; }
    }
    public class UserDto
    {
        public string Name { get; set; }
        public string Passord { get; set; }
        public string Email { get; set; }
        public UserDto FromModel(User user)
        {
            Name = user.Name;
            Passord = user.Passord;
            Email = user.Email;
            return this;
        }
        public User UpdataModel(User user)
        {
            user.Name = Name;
            user.Email = Email;
            return user;
        }
    }
