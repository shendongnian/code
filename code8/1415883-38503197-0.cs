    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class SomeModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
    }
    public class SomeModelDetailsResponseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
