    public class UserGroup_ViewModel
    {
        public List<User> Users { get; set; }
        public List<Group> Groups { get; set; }
    }
.
    public UserGroup_ViewModel GetUserAndGroups()
        {
            using(var _uow = new UserManagement_UnitOfWork())
            {
                _UserAndGroupModel.Users = _uow.User_Repository.GetAll().ToList();
                _UserAndGroupModel.Groups = _uow.Group_Repository.GetAll().ToList();
                return _UserAndGroupModel;
            }
            
        }
