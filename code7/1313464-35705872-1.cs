    public static class MustFindProjectByIdExtensions {
        public static IRuleBuilderOptions<T, int> MustFindProjectById<T>
            (this IRuleBuilder<T, int> ruleBuilder, DbContext dbContext) {
            return ruleBuilder.SetValidator(new MustFindProjectById(dbContext));
        }
    }
