    public class MgtRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            rental_dbEntities db = new rental_dbEntities();
            string userRole = string.Empty;
            string adminRole = string.Empty;
            
            var user = db.TblUsers.Where(a => a.username == username).FirstOrDefault()
            if (user != null)
            {
                userRole = user.role;
            }
    
            var admin = db.TblAdmins.Where(a => a.username == username).FirstOrDefault();       
            if (admin != null)
            {
                 adminRole = admin.role;
            }
    
            string[] result = { userRole, adminRole };
            return result;
        }
    }
