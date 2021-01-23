    public class AndroidSecuredDataProvider : ISecuredDataProvider
    {
        public void Store(string userId, string providerName, IDictionary<string, string> data)
        {
            Clear(providerName);
            var accountStore = AccountStore.Create(Android.App.Application.Context);
            var account = new Account(userId, data);
            accountStore.Save(account, providerName);
        }
        public void Clear(string providerName)
        {
            var accountStore = AccountStore.Create(Android.App.Application.Context);
            var accounts = accountStore.FindAccountsForService(providerName);
            foreach (var account in accounts)
            {
                accountStore.Delete(account, providerName);
            }
        }
        public Dictionary<string, string> Retreive(string providerName)
        {
            var accountStore = AccountStore.Create(Android.App.Application.Context);
            var accounts =  accountStore.FindAccountsForService(providerName).FirstOrDefault();
            return (accounts != null) ? accounts.Properties : new Dictionary<string, string>();
        }
    }
