    public List<User> getUsers (List<int> ids)        
    {
        using(var uow = _repository.CreateUnitOfWork())
        {               
            var allUsers = uow.GetEntities<User>();
            var matchingUsers = allUsers
                .Where(user => ids.Contains(user.Id))
                .ToList();
            return matchingUsers.Any() ? matchingUsers : allUsers.ToList();
        }
    }
