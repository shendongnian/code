         public async Task<IEnumerable<UsersViewModel>> GetUsersList()
            {
                var t = new Task<IEnumerable<Users>>(() => _db.Users.ToEnumerable());
                t.Start();          
                IEnumerable<Users> z = await t;
                var vm = Mapper.Map<IEnumerable<Users>, IEnumerable<UsersViewModel>>(z);
                return vm.OrderBy(x => x.Login);
            }
