    using Domain;
    using ViewModel;
    public class UserController
    {
        public Save(Model.User user)   
        {
            Domain.User dUser = Mapper.Map(user);
            repository.Save(dUser);
        }
    }
