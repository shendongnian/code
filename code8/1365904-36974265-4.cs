    internal class UserRegisterService : IUserRegisterService
    {
        private readonly IActiveDirectoryRepository _repoAd;
        internal UserRegisterService(IActiveDirectoryRepository repoAd)
        {
            _repoAd = repoAd;
        }
    }
