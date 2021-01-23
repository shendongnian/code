    public class RegisterUserViewModel
    {
        public List<SelectListItem> UsersSelectListItems { get; set; }
    }
    var users = from u in db.UsersAndRoles
        select new
        {
            u.Id, u.Name
        };
