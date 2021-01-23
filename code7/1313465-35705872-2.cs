    internal class MustFindProjectById : PropertyValidator {
        private readonly DbContext _dbContext;
        internal MustFindProjectById(DbContext dbContext) {
            _dbContext = dbContext;
        }
    
        protected override IsValid(PropertyValidatorContext) {
            var projectId = (int)context.PropertyValue;
            var entity = dbContext.Projects.Find(projectId);
            return entity != null;
        }
    }
