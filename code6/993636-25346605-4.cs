    public class UserListController : ApiController
    {
        private TodoItemContext db = new TodoItemContext();
        // GET api/userList
        public List<UserDto> GetUserLists()
        {
            var u = new User
            {
                Email = "test@test.com",
                FirstName = "first",
                LastName = "last",
                AccountId = "1324"
            };
            List<UserDto> users = new List<Models.UserDto>();
            users.Add(new UserDto(u));
            return users;
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
