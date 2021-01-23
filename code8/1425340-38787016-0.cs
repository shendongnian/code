    public IEnumerable<User> GetUsersByIdOrAllUsers(IEnumerable<int> ids)
    {
        using (var uow = _repository.CreateUnitOfWork())
        {
            var users = uow.GetEntities<User>();
            if (users.Any(c => ids.Contains(c.ID)))
            {
                return users.Where(c => ids.Contains(c.ID));
            }
            return users;
        }
    }
