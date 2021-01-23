    public class User : BaseClass
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class BaseClass
    {
        public void Save()
        {
           //put save logic here. Should match for all 
           //concrete implementations of BaseClass
        }
    }
