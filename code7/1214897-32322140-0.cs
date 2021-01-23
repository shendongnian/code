    public interface IAccount
    {
    
    }
    
    public class Account :  Xamarin.Auth.Account, IAccount
    {
        public Account(Xamarin.Auth.Account account) :
            base(account.Username, account.Properties, account.Cookies)
        {
        }
    }
    
    _account = new YourNamespace.Account(eventArgs.Account);
    
