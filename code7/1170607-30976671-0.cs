    namespace DataRepository.Models
    {
        public class MyUser
        {
            public int Id { get; }
            //define other user properties
        }       
    }
    namespace SomeOtherNamespace
    {
        public class MyIdentityUser : IdentityUser
        {
            private MyUser _User;
            
            public MyIdentityUser(MyUser user)
            {
                _User = user;
            }
            public int Id { get { return _User.Id; } }
            //define other IdentityUser properties by using the MyUser object
        }
    }
    
