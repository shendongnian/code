    interface IMembershipRepository
    {
        List<UserProfile> GetUsersForManager(Guid managerId);
    }
    class SqlServerMembershipRepository : IMembershipRepository
    {
        private readonly string ConnectionString;
    
        public SqlServerMembershipRepository(string connectionString)
        {
            //Any initialization of the repository goes here
            ConnectionString = connectionString;
        }
        public List<UserProfile> GetUsersForManager(Guid managerId)
        {
            using (var context = new ApplicationDbContext(connectionString))
            {
                var userIds = context.ManagersUsers.Where(u => u.ManagerId == myId).Select(u => u.UserId.ToString()).ToList();
    
                var userProfiles = context.Users.Where(t => userIds.Contains(t.Id)).ToList();
    
               return View(userProfiles);
            }
        }
    }
