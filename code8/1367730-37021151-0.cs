    class UserService{
      ...
      IEnumerable<UserVM> GetUsers(){
        return (from user in UserRepository.GetQuery()
        join acc in AccountsRepository.GetQuery()
        on user.Id equals acc.userId
        select new <UserVM>{
          Name=user,
          Count=OrdersRepository.GetCountByUserId(user.Id);
        }).ToList();
      }
    }
    class UserVM{
        User User {get; private set;}
        int Count {get; private set;}
    }
