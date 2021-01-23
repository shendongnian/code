    public class UserManagement_Services
    {
         public UserGroup_ViewModel GetUserAndGroups()
         {
              UserGroup_ViewModel _UserAndGroupModel = new UserGroup_ViewModel();
              using(var _uow = new UserManagement_UnitOfWork())
              {
                  _UserAndGroupModel.Users = _uow.User_Repository.GetAll();
                  _UserAndGroupModel.Groups = _uow.Group_Repository.GetAll();
              }
              return _UserAndGroupModel;
         }
    }
