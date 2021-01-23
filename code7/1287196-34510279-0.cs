    public class UsersModel {
        public List<string> Users { get; private set; }
        public void LoadUsers() {
            Users = ...
        }
    }
    public class HomeController
    {
       var um = new UsersModel();
       um.LoadUsers();
       var users = um.Users;
    }
