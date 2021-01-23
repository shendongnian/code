    public class UserDto
    {
      public int Id {get;set;}
      public string Name {get;set;} 
      public UserTypeDto UserType { set; get; }    
    }
    public class UserTypeDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
