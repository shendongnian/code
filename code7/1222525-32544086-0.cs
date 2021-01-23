    public class User
            {
                public int ID { get; set; }
                public string Name { get; set; }
                public string Type { get; set; }
                **public List<Wepon> WeposInList { get; set; }**
                 
                }
      
   
     public class Wepon
        {
            public int ID { get; set; }
            public string Wepon_Name { get; set; }
            public int Power { get; set; }
            public List<User> UsersHaveWeponsList { get; set; }// User the List for M to M
    }
