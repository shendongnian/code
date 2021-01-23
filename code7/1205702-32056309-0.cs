    public class User
        {
            public int Id {get; set; }
            public string Name {get; set;}
    
            public User getUser(int tId)
            {
                var user = DbConnection.Table<User>().Where(x => x.Id == tId).FirstOrDefault();
                Id = user.Id;
                Name = user.Name;
                //age = user.age; // not possible
            }        
        }
    
        public class DetailedUser:User
        {
            public int age { get; set; }   
          
            public DetailedUser getUser(int tId)
            {
                var user = DbConnection.Table<User>().Where(x => x.Id == tId).FirstOrDefault();
                base.Id = user.Id;
                base.Name = user.Name;
                //age = user.age; // not possible
            }
    
            public DetailedUser getDetailedUser(int tId)
            {
                var user = DbConnection.Table<DetailedUser>().Where(x => x.Id == tId).FirstOrDefault();
                base.Id = user.Id;
                base.Name = user.Name;
                age = user.age;
            }
        }
