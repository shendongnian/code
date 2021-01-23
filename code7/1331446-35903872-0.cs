    public class UserViewModel : INotifyPropertyChanged
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        // INotifyPropertyChanged implementation or use Fody
    }
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual GroupModel Group { get; set; }
    }
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<UserModel> Users { get; set; } 
    }
    public class UserRepository
    {
        public IEnumerable<UserViewModel> GetUsers()
        {
            using (var db = new YourDbContext())
            {
                return (
                    from user in db.Users
                    select new UserViewModel
                    {
                        UserId = user.Id,
                        UserName = user.Name,
                        GroupId = user.Group.Id,
                        GroupName = user.Group.Name,
                    }).ToArray();
            }
        }
        public void SaveChanges(UserViewModel user)
        {
            using (var db = new YourDbContext())
            {
                // get user
                // modify and...
                db.SaveChanges();
            }
        }
    } 
