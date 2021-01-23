    public async Task<IEnumerable<UsersViewModel>> GetUsersList()
    {
      var users = await new Task<IEnumerable<Users>>(() => _db.Users.ToEnumerable());
      var vm = Mapper.Map<IEnumerable<Users>, Task<IEnumerable<UsersViewModel>>>(t);
      return vm.Result.OrderBy(x => x.Login);
    }
