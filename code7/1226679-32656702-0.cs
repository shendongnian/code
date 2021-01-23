    public class ViewHelpers
    {
        public static SelectList TechList(int status, guid role)
        {
            using (var db = new DbContext())
            {
                return new SelectList(db.Users.Where(u => u.Status == status & u.RoleID == role).OrderBy(u => u.FullName).ToList(), "UserId", "FullName");
            }
        }
    }
