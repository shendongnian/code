    public static void Update(
        Expression<Func<User, bool>> condition,
        User user,
        PropertyInfo[] propertiesToUpdate)
    {
        Expression<Func<User, User>> updateFactory =
            Expression.Lambda<Func<User, User>>(
                Expression.MemberInit(
                    Expression.New(typeof (User)),
                    propertiesToUpdate
                        .Select(prop =>
                            Expression.Bind(
                                prop.SetMethod,
                                Expression.Constant(prop.GetValue(user))))),
                Expression.Parameter(typeof(User), "u"));
        ctx.Users
            .Where(condition)
            .Update(updateFactory);
    }
