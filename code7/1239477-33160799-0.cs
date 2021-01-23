    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<TOuterClass, TUser> StateIsValid<TOuterClass, TUser>(this IRuleBuilder<TOuterClass, TUser> ruleBuilder)
            where TUser : User
        {
            return ruleBuilder
                .Must(user => IsStateOfCountry(user.State, user.Country));
        }
    }
