    public void Update(
        Expression<Func<User,bool>> condition,
        Expression<Func<User,User>> updateFactory)
    {
        ctx.Users
           .Where(condition)
           .Update(updateFactory);
    }
