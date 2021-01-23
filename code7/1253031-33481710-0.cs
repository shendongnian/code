    public class MgtRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            rental_dbEntities db = new rental_dbEntities();
            string userRole = db.TblUsers.Where(a => a.username == username).FirstOrDefault().role;
    
            string adminRole = db.TblAdmins.Where(a => a.username == username).FirstOrDefault().role;        
    
            string[] result = { userRole, adminRole };
            return result;
        }
    }
