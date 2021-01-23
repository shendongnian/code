    public class CurrentUserStructure{
        private List<CurrentUserStructure.ListUserClass> users;
        public List<CurrentUserStructure.ListUserClass> Users{
            get {
                    if(users==null){
                        users = GetUserList();
                    }
                    return users;
                }
        }
    
        // Note that this method is now private
        private List<CurrentUserStructure.ListUserClass> GetUserList() {
            // Implement your logic here
        }
    }
