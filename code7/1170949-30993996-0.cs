    class User : IUser<int>
    {
       public int Id
       { get; set; }
    
       public string Name
       { get; set; }
       
       public string Email
       { get; set; }
       public string PasswordHash
       { get; set; }
       public string SecurityStamp
       { get; set; }
    
       // other fields here
    
       string IUser<int>.UserName
       {
          get { return Email; }
          set { Email = value; }
       }
    }
