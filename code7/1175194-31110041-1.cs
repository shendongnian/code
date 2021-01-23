    public class UserModel
     {
        public UserModel()   // constructor
        {
            Permissions = new Dictionary<Guid, List<Guid>>();
        }
        public Dictionary<Guid, List<Guid>> Permissions { get; set; }
      }
