    public class UserGroup_ViewlModel
    {
         public UserGroup_ViewlModel()
         {
              Users = new List<User>();
              Groups = new List<Group>();
         }
         public List<User> Users { get; set; }
    
         public List<Group> Groups { get; set; }
    }
