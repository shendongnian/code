cs
using System;
using System.Linq;
using Windows.System;
using Windows.UI.Xaml.Controls;
namespace App_1
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetUserInfo();
        }
        public static async void GetUserInfo()
        {
            var users = await User.FindAllAsync(UserType.LocalUser);
            var user = await users.FirstOrDefault().GetPropertyAsync(KnownUserProperties.AccountName);
            var user_count = users.Count;
            var AccountName =
                await users[0].GetPropertyAsync(KnownUserProperties.AccountName);
            var DisplayName =
                await users[0].GetPropertyAsync(KnownUserProperties.DisplayName);
            var DomainName =
                await users[0].GetPropertyAsync(KnownUserProperties.DomainName);
            var FirstName =
                await users[0].GetPropertyAsync(KnownUserProperties.FirstName);
            var GuestHost =
                await users[0].GetPropertyAsync(KnownUserProperties.GuestHost);
            var LastName =
                await users[0].GetPropertyAsync(KnownUserProperties.LastName);
            var PrincipalName =
                await users[0].GetPropertyAsync(KnownUserProperties.PrincipalName);
            var ProviderName =
                await users[0].GetPropertyAsync(KnownUserProperties.ProviderName);
            var SessionInitiationProtocolUri =
                await users[0].GetPropertyAsync(KnownUserProperties.SessionInitiationProtocolUri);
            var User_Type = users[0].Type;
        }
    }
}
[![all_null][1]][1]
  [1]: https://i.stack.imgur.com/VuoW3.png
