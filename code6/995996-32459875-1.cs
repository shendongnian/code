    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int VirtualId { get; set; }
    
    }
    
    public class Code
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
    }
