    public class User<TCustomUser> where TCustomUser : User<TCustomUser>
    {
        public TCustomUser creator {get;set;}
        public TCustomUser deletor {get;set;}
        //not convenient variant, without generic approach
        //public User creator {get;set;}
        //public User deletor {get;set;}     
    }
    
    public class CustomUser : User<CustomUser>
    {
        //custom fields:
        public string City {get;set;}
        public int Age {get;set;}
    }
