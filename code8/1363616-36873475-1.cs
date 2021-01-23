      public class AccountContext : DbContext, IContext
        {
            
            public AccountContext(string nameOrConnectionString)
                : base(nameOrConnectionString)
            {
                Database.SetInitializer<AccountContext>(null);
                this.Configuration.ProxyCreationEnabled = false;
                this.Configuration.LazyLoadingEnabled = false;
            }
    
            public IDbSet<Account> Accounts{ get; set; }
    ....
    }
