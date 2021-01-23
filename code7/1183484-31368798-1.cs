    public List<User> GetUsers(Expression<Func<User, bool>> where)
    {
        return _entity.Where(where).ToList();
    }
    var users = _acc.GetUsers(x => x.Id == 1);
