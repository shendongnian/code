    using DUser = Domain.User;
    using VMUser = ViewModel.User;
    public class UserController
    {
        public Save(VMUser user)   
        {
            DUser dUser = Mapper.Map(user);
            repository.Save(dUser);
        }
    }
