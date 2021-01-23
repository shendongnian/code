    public class UserLimitProvider : IUserLimitProvider
    {
      public UserLimitProvider(
        ICustomerService customerService,
        IMoneyService moneyService,
        ILimitService limitService)
      {
        // store these in private fields
      }
      public IAccountLimit GetLimitForUser(string userName)
      {
        var customer = _customerService.Find(userName);
        return new AccountLimit(customer.Id, _moneyService, _limitService);
      }
    }
