    public class Manage
    {
        private VatsWebEntitiesManage ManageEntity = new VatsWebEntitiesManage();
                
        public List<AspNetUser> Users { get; set; }
    
        public List<AspNetUser> FetchUserDetails()
        {
            var users = ManageEntity.AspNetUsers.ToList();
            return Users = users;
        }
    }
