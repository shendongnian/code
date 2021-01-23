    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public User()
        {
    
        }
    
        public static User GetUser(int id)
        {
            return dataContext.Users.FirstOrDefault(q => q.ID == id);
        }
    }
