        public class UserModel
        {
           public Dictionary<Guid, List<Guid>> Permissions { get; set; }
           public UserModel()   // constructor
           {
               Permissions = new Dictionary<Guid,List<Guid>>();
           }
        
        }​
