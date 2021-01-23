    public class AdminSelectableUserRepositoryProxy : IUserRepository
    {
        private readonly AdministratorUserRepository adminRepo;
        private readonly NormalUserRepository normalRepo;
        private readonly IUserContext userContext;
        public AdminSelectableUserRepositoryProxy(
            AdministratorUserRepository adminRepo, 
            NormalUserRepository normalRepo,
            IUserContext userContext)
        {
            this.adminRepo = adminRepo;
            this.normalRepo = normalRepo;
            this.userContext = userContext;
        }
        public User GetById(Guid id)
        {
            return this.Repository.GetById(id);
        }
        private IUserRepository Repository
        {
            get 
            {
                return this.userContext.IsAdministrator ? this.adminRepo : this.normalRepo;
            }
        }
    }
