    public class BtnValidator
    {
        private readonly IDbContext _dbContext;
        public BtnValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool IsValid(string ID) {
            var result = _dbContext.Blogs.FirstOrDefault(x => x.ID == ID);
            return result != null;
        }
    }
