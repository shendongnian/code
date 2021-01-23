    public class OrmLiteAuthRepository 
        : OrmLiteAuthRepository<UserAuth, UserAuthDetails>, IUserAuthRepository
    {
        public OrmLiteAuthRepository(IDbConnectionFactory dbFactory) 
            : base(dbFactory) { }
    }
