    public class BtnValidator
    {
        private readonly IDbContext _dbContext;
        public BtnValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
